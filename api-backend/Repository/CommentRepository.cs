using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Models;
using api_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public interface ICommentRepository
    {
        Task<Comentario> CreateAsync(Comentario postModel);
        Task<Comentario?> DeleteAsync(Guid id);
        Task<Comentario?> UpdateAsync(Guid id, Comentario postModel);
    }

    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comentario> CreateAsync(Comentario postModel)
        {
            await _context.Comentarios.AddAsync(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }
        public async Task<Comentario?> DeleteAsync(Guid id)
        {
            var postModel = await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);

            if (postModel == null)
            {
                return null;
            }

            _context.Comentarios.Remove(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }
        public async Task<Comentario?> UpdateAsync(Guid id, Comentario postModel)
        {
            var existingPost = await _context.Comentarios.Where(x => x.Id == id)
                .Include(x => x.AppUser)
                .Include(x => x.Avaliacoes)
                .FirstAsync();

            if (existingPost == null)
            {
                return null;
            }

            existingPost.Content = postModel.Content;

            await _context.SaveChangesAsync();

            return existingPost;
        }
    }
}