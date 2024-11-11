using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Post;
using api_backend.Extensions;
using api_backend.Mappers;
using api.Models;
using api.Repository;
using api_backend.Mappers;
using api_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using api.Dtos.Comment;

namespace api.Controllers
{
    [Route("api/Comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository postRepo,
        UserManager<AppUser> userManager)
        {
            _commentRepo = postRepo;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto PostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsernameOrEmail();
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
                appUser = await _userManager.FindByEmailAsync(username);

            var item = new Comentario
            {
                AppUserId = appUser?.Id,
                PostId = PostDto.PostId,
                Content = PostDto.Content
            };
            var retono = await _commentRepo.CreateAsync(item);

            return Ok(retono);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = new Comentario { 
            Content = updateDto.Content
            };
            var Post = await _commentRepo.UpdateAsync(id, item);

            if (Post == null)
            {
                return NotFound("Post not found");
            }

            return Ok(Post);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PostModel = await _commentRepo.DeleteAsync(id);

            if (PostModel == null)
            {
                return NotFound("Post does not exist");
            }

            return Ok(PostModel);
        }
    }
}