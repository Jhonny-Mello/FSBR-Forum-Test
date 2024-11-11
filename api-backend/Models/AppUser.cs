using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public List<Avaliacao> Avaliacao { get; set; } = new List<Avaliacao>();
    }
}