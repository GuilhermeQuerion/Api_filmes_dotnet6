using System.ComponentModel.DataAnnotations;

namespace Curso_Api6.Dtos {
    public class UpdateFilmeDto {
        [Required(ErrorMessage = "Título obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O genero deve conter 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Duracao do filme deve ser de 1 a 600")]
        public int Duracao { get; set; }
    }
}
