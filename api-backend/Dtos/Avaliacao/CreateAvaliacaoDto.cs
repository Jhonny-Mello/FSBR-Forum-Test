using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Avaliacao
{
    public class CreateAvaliacaoDto
    {
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        [Range(1, 5)]
        public int value { get; set; } = 0;
    }
}