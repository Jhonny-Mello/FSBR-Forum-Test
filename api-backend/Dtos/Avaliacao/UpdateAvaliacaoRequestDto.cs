using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Avaliacao
{
    public class UpdateAvaliacaoRequestDto
    {
        [Required]
        [Range(1,5)]
        public int value { get; set; } = 0;
    }
}