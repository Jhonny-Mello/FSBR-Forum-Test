using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Models;
using api_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace api.Repository
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> CreateOrUpdateAsync(Guid id, Avaliacao value);
        Task<Avaliacao?> DeleteAsync(Guid id);
    }

    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ApplicationDBContext _context;
        public AvaliacaoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Avaliacao> CreateOrUpdateAsync(Guid id, Avaliacao postModel)
        {
            try
            {
                var ispost =_context.Posts.Where(x => x.Id == id).FirstOrDefault();
                if(ispost != null)
                {
                    postModel.PostId = id;
                    postModel.CommentId = null;
                }
                var iscomment = _context.Comentarios.Where(x => x.Id == id).FirstOrDefault();
                if (iscomment != null)
                {
                    postModel.PostId = null;
                    postModel.CommentId = id;
                }

                if (_context.Avaliacoes.Any(x => (x.PostId == id || x.CommentId == id) && x.AppUserId == postModel.AppUserId))
                {
                    var existingPost = await _context.Avaliacoes.Where(x => (x.PostId == id || x.CommentId == id)
                    && x.AppUserId == postModel.AppUserId).FirstAsync();

                    if (existingPost == null)
                    {
                        return null;
                    }

                    existingPost.Value = postModel.Value;

                    await _context.SaveChangesAsync();
                }
                else
                {

                    postModel.CreatedOn = DateTime.Now;

                    if (_context.Posts.Any(x => x.Id == id))
                    {
                        postModel.PostId = id;
                    }

                    if (_context.Comentarios.Any(x => x.Id == id))
                    {
                        postModel.CommentId = id;
                    }

                    await _context.Avaliacoes.AddAsync(postModel);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            return postModel;
        }
        public async Task<Avaliacao?> DeleteAsync(Guid id)
        {
            var postModel = await _context.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);

            if (postModel == null)
            {
                return null;
            }

            _context.Avaliacoes.Remove(postModel);
            await _context.SaveChangesAsync();
            return postModel;
        }
    }
}