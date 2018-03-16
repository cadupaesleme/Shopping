using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saphyr.Models
{
    public class Gerente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Matrícula obrigatória")]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        public virtual ICollection<Shopping> Shopping { get; set; }
    }
}