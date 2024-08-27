using ApiLivros.Enums;

namespace ApiLivros.Models
{
    public class LivroModel
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public GeneroEnum genero { get; set; }

        public AvaliacaoEnum avaliacao { get; set; }
    }
}
