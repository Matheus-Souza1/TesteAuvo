namespace TesteAuvo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrevisaoClima")]
    public partial class PrevisaoClima
    {
        public int Id { get; set; }

        public int CidadeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataPrevisao { get; set; }

        [Required]
        [StringLength(15)]
        public string Clima { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TemperaturaMinima { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TemperaturaMaxima { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
