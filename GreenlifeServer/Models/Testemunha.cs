using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_TESTEMUNHA")]
    public class Testemunha
    {
        [Column("Id")]
        public int TestemunhaId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(80, ErrorMessage = "Este campo deve conter no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres.")]
        public string Telefone { get; set; }
    }
}
