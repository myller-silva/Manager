namespace ToDo.Services.DTO;

public class UserDTO
{
    public long Id { get; set; }
    public string Name { get; set; } //apaga os private set pq nao precisa ser uma entidade fechada
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDTO()
    {}
    
    public UserDTO(long id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}