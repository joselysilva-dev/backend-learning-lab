using System.ComponentModel.DataAnnotations;

namespace MinhaPrimeiraApi.DTOs;

public class AlunoUpdateDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; } = string.Empty;
}