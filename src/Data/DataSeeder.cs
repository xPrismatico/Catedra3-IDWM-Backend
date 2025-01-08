using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bogus;
using api.src.Models;
using System.Text.RegularExpressions;

namespace api.src.Data
{
    public class DataSeeder
    {
        // Uso Bougos para agregar todos los datos a la Base de datos

        /**
        * Método para inicializar la base de datos con datos de prueba
        */
        public static void Initialize(IServiceProvider serviceProvider){


            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider; // provider de bogus
                var context = services.GetRequiredService<DataContext>(); //Context de dotnet que conectamos con la DBContext
                
                List<User> users = new List<User>();

                // Datos del User
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new User{
                        Email = "idwm@gmail.com",
                        Password = "idwm123123"});

                    var userFaker = new Faker<User>()
                        .RuleFor(u => u.Email, f => f.Person.Email)
                        .RuleFor(u => u.Password, f => GeneratePassword(f));

                    users = userFaker.Generate(15);


                    context.Users.AddRange(users);
                    context.SaveChanges();
                }


                // Datos de los Posts
                if (!context.Posts.Any())
                {
                    var postFaker = new Faker<Post>()
                        .RuleFor(p => p.Title, f => f.Lorem.Sentence(5))
                        .RuleFor(p => p.PublishDate, f => f.Date.Past())
                        .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
                        .RuleFor(p => p.UserId, f => f.PickRandom(users).UserId);

                    var posts = postFaker.Generate(15);
                    context.Posts.AddRange(posts);
                    context.SaveChanges();
                }

            }
        }

        /**
        * Método para Generar una contraseña aleatoria con al menos un número y 6 carácteres
        */
        private static string GeneratePassword(Faker faker)
        {
            string password;
            do
            {
                password = faker.Internet.Password(6);
            } while (!Regex.IsMatch(password, @"\d"));
            return password;
        }
    }
}