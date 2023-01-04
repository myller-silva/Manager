using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository) //criando instancias de interfaces??
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    //obs: nao esquecer de adicionar o "async"
    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);
        if (userExists != null)
            throw new DomainException("Já existe usuario cadastrado com o email informado.");
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userCreated = await _userRepository.Create(user);
        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);

        if (userExists == null)
            throw new DomainException("Nao existe nenhum usuario com o Id informado!");
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        var userUpdated = await _userRepository.Update(user);
        
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task Remove(long id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDTO> Get(long id)
    {
        //obs: nao esquecer de usar o "await"
        var user = await _userRepository.Get(id);
        return _mapper.Map<UserDTO>(user);

    }
    public async Task<List<UserDTO>> Get()
    {
        var allUsers = await _userRepository.Get();
        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        return _mapper.Map<UserDTO>(user);
    }


    public async Task<List<UserDTO>> SearchByName(string name)
    {
        var users = await _userRepository.SearchByName(name);
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var users = await _userRepository.SearchByEmail(email);
        return _mapper.Map<List<UserDTO>>(users);
    }
}