using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Entidade
{
    [Table("SolicitacaoEmail")]
    public class SolicitacaoEmail
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Titulo")]
        public string Titulo { get; set; }
        [Column("Mensagem")]
        public string Mensagem { get; set; }
        [Column("Destinatarios")]
        public string Destinatarios { get; set; }
        [Column("Enviado")]
        public bool Enviado { get; set; }
    }
}
