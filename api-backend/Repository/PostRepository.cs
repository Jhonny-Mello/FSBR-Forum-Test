using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(Post postModel);
        Task<Post?> DeleteAsync(Guid id);
        Task<List<Post>> GetAllAsync(GenericPaginationModel<PainelForum> queryObject);
        Task<Post?> GetByIdAsync(Guid id);
        Task<Post?> UpdateAsync(Guid id, Post postModel);
    }

    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDBContext _context;
        public PostRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Post> CreateAsync(Post postModel)
        {
            await _context.Posts.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }

        public async Task<Post?> DeleteAsync(Guid id)
        {
            try
            {
                var postModel = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

                if (postModel == null)
                {
                    return null;
                }

                _context.Posts.Remove(postModel);
                _context.Avaliacoes.RemoveRange(_context.Avaliacoes.Where(x=> x.PostId == id));
                await _context.SaveChangesAsync();
                return postModel;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<List<Post>> GetAllAsync(GenericPaginationModel<PainelForum> queryObject)
        {
            var posts = _context.Posts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.Value.search))
            {
                // Busca dentro do texto do post ou de seus respectivos comentários
                posts = posts.Where(x => EF.Functions.Like(x.PostContent, $"%{queryObject.Value.search}%") || (x.Comentarios.Any(y => EF.Functions.Like(y.Content, $"%{queryObject.Value.search}%"))));
            };
            if (queryObject.Value.avaliacao != 0)
            {
                posts = posts.Where(x => x.Avaliacoes.Average(x => x.Value) == queryObject.Value.avaliacao);
            }

            if (queryObject.Value.IsDescending == true)
            {
                posts = posts.OrderByDescending(c => c.CreatedOn);
            }
            else
            {
                posts = posts.OrderBy(c => c.CreatedOn);
            }

            return await posts
                .Include(x => x.Comentarios)
                .ThenInclude(x => x.Avaliacoes)
                .Include(x => x.Comentarios)
                .ThenInclude(x => x.AppUser)
                .Include(x => x.AppUser)
                .Include(x => x.Avaliacoes)
                .ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.Include(a => a.AppUser)
                .Include(x => x.Comentarios)
                .ThenInclude(x => x.Avaliacoes)
                .Include(x => x.Avaliacoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Post?> UpdateAsync(Guid id, Post postModel)
        {
            var existingPost = await _context.Posts.Where(x => x.Id == id).Include(x => x.AppUser).FirstAsync();

            if (existingPost == null)
            {
                return null;
            }

            existingPost.Tema = postModel.Tema;
            existingPost.PostContent = postModel.PostContent;

            await _context.SaveChangesAsync();

            return existingPost;
        }
    }
}