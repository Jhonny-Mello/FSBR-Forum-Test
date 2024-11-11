using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key] 
        public Guid Id { get; set; }
        public Guid? PostId { get; set; } = null;
        public Guid? CommentId { get; set; } = null;
        public string AppUserId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedOn { get; set; }
        public AppUser AppUser { get; set; }
        public Post? Post { get; set; }
        public Comentario? Comentario { get; set; }

    }
}