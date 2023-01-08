using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels;
 
public class UpdateUserViewModel
{
    
    [Required(ErrorMessage = "A propriedade Id nao pode ser vazia.")]
    // [Range(1 , int.MaxValue, ErrorMessage = "A propriedade Id deve ser maior que 0.")]
    public long Id { get; set; }
    
    
    [Required(ErrorMessage = "A propriedade Name nao pode ser vazia.")]
    [MinLength(3, ErrorMessage = "A propriedade Name deve ter no minimo 3 caracteres." )]
    [MaxLength(80, ErrorMessage = "A propriedade Name deve ter no maximo 80 caracteres.")]
    public string Name { get;  set; }
     
    [Required(ErrorMessage = "A propriedade Email nao pode ser vazia.")]
    [MinLength(10, ErrorMessage ="A propriedade Email deve ter no minimo 10 caracteres.")]
    [MaxLength(180, ErrorMessage = "A propriedade Email deve ter no maximo 180.")]
    [RegularExpression(
        // pesquisar sobre regular expression
        @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1-3}\.)|(([\w-]+\.)+))([a-zA-z]{2,4}|[0-9]{1,3})(\]?)$",
        ErrorMessage = "O email informado nao é valido."
    )]
    public string Email { get;  set; }
    
    [Required(ErrorMessage = "A propriedade Password nao pode ser vazia.")]
    [MinLength(8, ErrorMessage = "A propriedade Password deve ter no minimo 8 caracteres.")]
    [MaxLength(30, ErrorMessage = "A propriedade Password deve ter no maximo 30 caracteres.")]
    public string Password { get;  set; }

    public UpdateUserViewModel(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    public UpdateUserViewModel()
    {
        // throw new NotImplementedException();
    }
}