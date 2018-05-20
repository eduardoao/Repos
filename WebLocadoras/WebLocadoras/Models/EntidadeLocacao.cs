using System;
using System.ComponentModel.DataAnnotations;

namespace WebLocadoras.Models
{
    public class EntidadeLocacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public EntidadeCliente Cliente { get; set; }
        public EntidadeFilme Filme { get; set; }
    }
}
