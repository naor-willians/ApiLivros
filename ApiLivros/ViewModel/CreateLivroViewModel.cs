using ApiLivros.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiLivros.ViewModel
{
    public class CreateLivroViewModel
    {
        [Required]
        public string titulo { get; set; }

        public GeneroEnum genero { get; set; }

        public AvaliacaoEnum avaliacao { get; set; }
    }
}
