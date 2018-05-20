using System.ComponentModel.DataAnnotations;

namespace WebLocadoras.Models
{
    public class EntidadeCliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
    }
}
