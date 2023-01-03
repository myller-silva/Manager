using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade nao pode ser vazia.")

            .NotNull()
            .WithMessage("A entidade nao pode ser nula.");
        
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("A propriedade Name nao pode ser nula.")

            .NotEmpty()
            .WithMessage("A propriedade Name nao pode ser vazia.")

            .MinimumLength(3)
            .WithMessage("A propriedade Name deve ter no minimo 3 caracteres.")
            
            .MaximumLength(80)
            .WithMessage("A propriedade Name deve ter no maximo 80 caracteres.");
        
        
        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("A propriedade Email nao pode ser nula.")

            .NotEmpty()
            .WithMessage("A propriedade Email nao pode ser vazia.")

            .MinimumLength(10)
            .WithMessage("A propriedade Email deve ter no minimo 10 caracteres.")

            .MaximumLength(180)
            .WithMessage("A propriedade Email deve ter no maximo 180.")

            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1-3}\.)|(([\w-]+\.)+))([a-zA-z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("O email informado é invalido.");


        
        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("A propriedade Password nao pode ser nula.")

            .NotEmpty()
            .WithMessage("A propriedade Password nao pode ser vazia.")

            .MinimumLength(8)
            .WithMessage("A propriedade Password deve ter no minimo 8 caracteres.")
            
            .MaximumLength(30)
            .WithMessage("A propriedade Password deve ter no maximo 30 caracteres.");


    }
}