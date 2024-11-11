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
using api.Dtos.Avaliacao;

namespace api.Controllers
{
    [Route("api/Avaliacao")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _AvaliacaoRepo;
        private readonly UserManager<AppUser> _userManager;
        public AvaliacaoController(IAvaliacaoRepository postRepo,
        UserManager<AppUser> userManager)
        {
            _AvaliacaoRepo = postRepo;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAvaliacaoDto PostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var item = new Avaliacao
            {
                Value = PostDto.value,
                PostId = PostDto.PostId,
                AppUserId = appUser.Id
            };

            var retono = await _AvaliacaoRepo.CreateOrUpdateAsync(PostDto.PostId,item);

            return Ok(retono);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var PostModel = await _AvaliacaoRepo.DeleteAsync(id);

            if (PostModel == null)
            {
                return NotFound("Post does not exist");
            }

            return Ok(PostModel);
        }
    }
}