using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testStartup.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id {get; set;}

        public string Descricao {get; set;}

        [Required(ErrorMessage = "Este cammpo não pode ser vazio")]
        public  float Preco{get; set;}



    }

}