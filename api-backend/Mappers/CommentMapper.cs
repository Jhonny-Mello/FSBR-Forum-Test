using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Post;
using api.Models;

namespace api_backend.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post PostModel)
        {
            return new PostDto
            {
                Id = PostModel.Id,
                Title = PostModel.Tema,
                Content = PostModel.PostContent,
                CreatedOn = PostModel.CreatedOn,
                CreatedBy = PostModel.AppUser.UserName,
            };
        }

        public static Post ToPostFromCreate(this CreatePostDto PostDto)
        {
            return new Post
            {
                Tema = PostDto.Title,
                PostContent = PostDto.Content,
                CreatedOn = DateTime.Now
            };
        }

        public static Post ToPostFromUpdate(this UpdatePostRequestDto PostDto, Guid postId)
        {
            return new Post
            {
                Tema = PostDto.Title,
                PostContent = PostDto.Content,
                Id = postId
            };
        }

    }
}