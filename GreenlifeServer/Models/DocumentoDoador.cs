using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenlifeServer.Models
{
    [Table("TB_DOCUMENTO_DOADOR")]
    public class DocumentoDoador
    {
        [Column("Id")]
        public int DocumentoDoadorId { get; set; }

        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int UsuarioId { get; set; }

        public Testemunha Testemunha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int TestemunhaId { get; set; }
    }
}
