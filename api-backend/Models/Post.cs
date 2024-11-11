using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string Tema { get; set; } = string.Empty;
        public string PostContent { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public List<Comentario> Comentarios { get; set; } = [];
        public List<Avaliacao> Avaliacoes { get; set; } = [];
        public AppUser AppUser { get; set; }
    }
}