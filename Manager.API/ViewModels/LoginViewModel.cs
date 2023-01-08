using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;

public class LoginViewModel
{
    
    [Required(ErrorMessage = "Login nao pode ser vazio")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Password não pode ser vazio")]
    public string Password { get; set; }
    
}