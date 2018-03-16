using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Saphyr.Models
{
    public class Shopping
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Área Total")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo deve ser númerico")]
        public float AreaTotal { get; set; }

        [Display(Name = "Número de Pisos")]
        [Range(0, int.MaxValue, ErrorMessage = "Número de Pisos deve ser Positivo")]
        public int NumeroPiso { get; set; }

        public virtual Gerente Gerente { get; set; }
        [ForeignKey("Gerente")]
        public int? GerenteId { get; set; }

        public virtual ICollection<Loja> Loja { get; set; }
    }
}