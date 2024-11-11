using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key] 
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string AppUserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Post Post { get; set; }
        public AppUser AppUser { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; } = [];
    }
}