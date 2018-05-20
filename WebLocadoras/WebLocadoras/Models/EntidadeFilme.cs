using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLocadoras.Models
{
    public class EntidadeFilme
    {
        [Key]
        public int Id { get; set; }
        public string Filme { get; set; }
        public string Genero { get; set; }

    }
}
