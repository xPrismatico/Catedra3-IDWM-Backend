using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra3_IDWM_Backend.src.DTOs;

namespace Catedra3_IDWM_Backend.src.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostDto>> GetAllPosts();
        Task CreatePost(CreatePostDto createPostDto, DateTime publishDate, string imageUrl);
    }
}