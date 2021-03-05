using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_ENDERECO")]
    public class Endereco
    {
        [Column("Id")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(80, ErrorMessage = "Este campo deve conter no máximo 80 caracteres.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int Numero { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(9, ErrorMessage = "Este campo deve conter no máximo 9 caracteres.")]
        public string Cep { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres.")]
        public string Estado { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 20 caracteres.")]
        public string Bairro { get; set; }
    }
}
