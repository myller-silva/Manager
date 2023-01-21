using ToDo.API.ViewModels;

namespace ToDo.API.Utilities;

public static class Responses
{
    public static ResultViewModel AplicationOkMessage(string message, dynamic data)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = true,
            Data = data
        };
    }
    public static ResultViewModel ApplicationErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "Ocorreu algum erro interno na aplicação.",
            Success = false,
            Data = null
        };
    }
    public static ResultViewModel ApplicationErrorMessage(string message, dynamic data)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = false,
            Data = data
        };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = false,
            Data = null
        };
    }
    
    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModel
        {
            Message = message,
            Success = false,
            Data = errors 
        };
    }

    public static ResultViewModel UnauthorizedErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "A combinação de login e senha está incorreta.",
            Success = false,
            Data = null
        };
        
    }
}