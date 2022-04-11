namespace TesteAuvo.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cidade")]
    public partial class Cidade
    {
        
        public Cidade()
        {
            PrevisaoClimas = new HashSet<PrevisaoClima>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual ICollection<PrevisaoClima> PrevisaoClimas { get; set; }
    }
}
