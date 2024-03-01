using MediatR;
using System.ComponentModel.DataAnnotations;
using TesteUniSystem.Models;

namespace TesteUnisystem.Recursos.Commands
{
    public class UsuarioUpdateCommand : IRequest<Usuario>
    {
        public int ID { get; set; }

        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
           "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage =
           "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        //Idade
        [Display(Name = "Idade", Description = "A idade deve estar entre 1 e 150 anos.")]
        [Range(1, 150)]
        public int Idade { get; set; }

    }
}
