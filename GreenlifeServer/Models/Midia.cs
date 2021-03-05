using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_MIDIA")]
    public class Midia
    {
        [Column("Id")]
        public int MidiaId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no máximo 30 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Arquivo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!"), DataType(DataType.Date)]
        public DateTime DataPostagem { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Fonte { get; set; }

        public string Substituto { get; set; }

        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int UsuarioId { get; set; }
    }
}
