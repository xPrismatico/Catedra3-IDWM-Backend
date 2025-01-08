using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.src.Controllers
{
    public class PostController : BaseApiController
    {
        // POST: api/posts
        // Crear un nuevo Post con imagen, requiere Auth

        /*
        [HttpPost("posts")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto){
            
            // Lógica de negocio respecto al Endpoint
            // Creación de un Post con Repository y Mapper

            // Validar JWT (Auth)
            //! TO DO


            // Validaciones de DTO
            //! TO DO


            // Transformar el DTO a Modelo
            var post = PostMapper.CreateDtoToModel(createPostDto);

            // Crear el Post a través del Repository
            var createdPost = await _postRepository.CreatePost(post);

            return TypedResults.Created("Post creado exitosamente", createdPost);
            
        }
        */
        



        // GET: api/posts
        // Obtener todos los Posts, requiere Auth
        /*

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
                return TypedResults.NotFound("No hay posts."); //
            }

            // Transformar los Posts a DTO
            var postsDto = PostMapper.CreateModelToDto(posts);

            return Ok(postsDto);
            
        
        }
        */
    }
}