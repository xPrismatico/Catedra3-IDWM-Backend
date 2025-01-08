using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra3_IDWM_Backend.src.DTOs;
using Catedra3_IDWM_Backend.src.Interfaces;
using Catedra3_IDWM_Backend.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers
{
    public class PostController: BaseApiController
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }


        // POST: api/posts
        // Crear un nuevo Post con imagen, requiere Auth

        
        [HttpPost("posts")]
        public async Task<IActionResult> CreatePost(CreatePostDto createPostDto){
            
            // Lógica de negocio respecto al Endpoint
            // Creación de un Post con Repository y Mapper

            // Validar JWT (Auth)
            //! TO DO


            // Validaciones de DTO
            //! TO DO


            // Transformar el DTO a Modelo
            //var post = PostMapper.CreateDtoToModel(createPostDto);
            // ese "post" mandalo por el _postRepository.CreatePost(post) y listo

            // Crear el Post a través del Repository
            await _postRepository.CreatePost(
                createPostDto, 
                DateTime.Now, 
                "https://www.ImageUrlExample.com");
                //!TO DO: Cambiar la URL de la imagen por la URL real de la imagen subida

            return Ok();
            
        }
        
        



        // GET: api/posts
        // Obtener todos los Posts, requiere Auth
        

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts(){
            
            
            // Lógica de negocio respecto al Endpoint
            // Obtención y Envío de todos los Posts con Repository y Mapper

            
            // Validar JWT (Auth)
            //! TO DO

            // Obtener todos los Posts con Repository
            var posts = await _postRepository.GetAllPosts();


            // Validar si existen Posts
            if (posts == null || !posts.Any()){
                return NotFound("No hay posts.");
            }

            // Transformar los Posts a DTO
            //var postsDto = PostMapper.CreateModelToDto(posts);

            return Ok(posts);
            
        
        }
        
    }
}