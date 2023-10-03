using System.ComponentModel.DataAnnotations;

namespace SIGEDESP.Models
{
    public class TipoDespesaModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o campo da Descrição")]
        public string tipoDespesa { get; set; }

    }
}
