using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_DEPOIMENTO")]
    public class Depoimento
    {
        [Column("Id")]
        public int DepoimentoId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(250, ErrorMessage = "Este campo deve conter no máximo 250 caracteres.")]
        public string Mensagem { get; set; }

        [MaxLength(800, ErrorMessage = "Este campo deve conter no máximo 800 caracteres.")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!"), DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int UsuarioId { get; set; }
    }
}
