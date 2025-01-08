using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.src.Data;
using api.src.Models;
using Catedra3_IDWM_Backend.src.DTOs;
using Catedra3_IDWM_Backend.src.Interfaces;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Catedra3_IDWM_Backend.src.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreatePost(CreatePostDto createPostDto, DateTime publishDate, string imageUrl){
            
            // Obtener UserId basado en el Email del CreatePostDto
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == createPostDto.Email);
            if (user == null)
            {
                throw new Exception("User no encontrado con el email proporcionado por el Post");
            }

            // Crear Post con datos de createPostDto
            var post = new Post{
                // postid se hace automatico
                Title = createPostDto.Title,
                PublishDate = publishDate,
                ImageUrl = imageUrl,
                UserId = user.UserId
            };

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<PostDto>> GetAllPosts(){
            return await _context
                .Posts.Select(post => new PostDto
                {
                    Title = post.Title,
                    PublishDate = post.PublishDate,
                    ImageUrl = post.ImageUrl,
                })
                .ToArrayAsync();
        }
    }
}