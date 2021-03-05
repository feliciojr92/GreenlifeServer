using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Column("Id")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no máximo 30 caracteres.")]
        public string PrimeiroNome { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(80, ErrorMessage = "Este campo deve conter no máximo 80 caracteres.")]
        public string Sobrenome { get; set; }
      
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter no máximo 50 caracteres.")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres.")]
        public string Senha { get; set; }
     
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(10, ErrorMessage = "Este campo deve conter no máximo 10 caracteres.")]
        public string NivelAcesso { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int Status { get; set; }

        [MaxLength(11, ErrorMessage = "Este campo deve conter no máximo 11 caracteres.")]
        public string Cpf { get; set; }

        [MaxLength(9, ErrorMessage = "Este campo deve conter no máximo 9 caracteres.")]
        public string Rg { get; set; }

        [MaxLength(11, ErrorMessage = "Este campo deve conter no máximo 11 caracteres.")]
        public string Telefone { get; set; }

        [MaxLength(3, ErrorMessage = "Este campo deve conter no máximo 3 caracteres.")]
        public string TipoSanguineo { get; set; }

        //Mapear a FK do relacionamento
        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int EnderecoId { get; set; }
    }
}
