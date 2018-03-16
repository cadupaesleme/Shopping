using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saphyr.Models
{
    public class Loja
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string CNPJ { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        public virtual Shopping Shopping { get; set; }

        [Required(ErrorMessage = "Escolha um Shopping")]
        public int ShoppingId { get; set; }
    }
}