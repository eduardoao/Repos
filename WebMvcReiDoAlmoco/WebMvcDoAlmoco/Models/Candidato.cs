using System.ComponentModel.DataAnnotations;

namespace WebMvcDoAlmoco.Models
{
    public class Candidato: BaseModel
    {
        public string Nome { get; set; }
        [Key] public string Email { get; set; }     

    }
}
