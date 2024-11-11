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

namespace api.Controllers
{
    [Route("api/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepo;
        private readonly UserManager<AppUser> _userManager;
        public PostController(IPostRepository postRepo,
        UserManager<AppUser> userManager)
        {
            _postRepo = postRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] GenericPaginationModel<PainelForum> queryObject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var posts = await _postRepo.GetAllAsync(queryObject);

            //var PostDto = posts.Select(s => s.ToPostDto());

            var lista = posts.Skip((queryObject.PageNumber - 1) * queryObject.PageSize)
                .Take(queryObject.PageSize);

            var totalRecords = posts.Count();
            var totalPages = ((double)totalRecords / (double)queryObject.PageSize);

            return Ok(PagedResponse.CreatePagedReponse(lista, queryObject, totalRecords));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Post = await _postRepo.GetByIdAsync(id);

            if (Post == null)
            {
                return NotFound();
            }

            return Ok(Post.ToPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreatePostDto PostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var PostModel = PostDto.ToPostFromCreate();
            PostModel.AppUserId = appUser.Id;
            await _postRepo.CreateAsync(PostModel);
            return CreatedAtAction(nameof(GetById), new { id = PostModel.Id }, PostModel.ToPostDto());
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePostRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Post = await _postRepo.UpdateAsync(id, updateDto.ToPostFromUpdate(id));

            if (Post == null)
            {
                return NotFound("Post not found");
            }

            return Ok(Post.ToPostDto());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PostModel = await _postRepo.DeleteAsync(id);

            if (PostModel == null)
            {
                return NotFound("Post does not exist");
            }

            return Ok(PostModel);
        }
    }
}