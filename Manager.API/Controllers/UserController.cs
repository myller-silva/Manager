using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase // pesquisar sobre controllers e sobre o ControllerBase
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper; //pesquisar sobre AutoMapper e o IMapper

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }  
    [HttpPost]
    // [Route("/api/v1/users/create")]
    // public async Task<IActionResult<List<User>>> Create([FromBody]CreateUserViewModel userViewModel)
    public async Task<ActionResult> Create([FromBody]CreateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDTO>(userViewModel); 
            var userCreated = await _userService.Create(userDto);
            return Ok(Responses.AplicationOkMessage("Usuario criado com sucesso!", userCreated));

            // return Ok(new ResultViewModel
            // { 
            //     Message = "Usuario criado com sucesso!",
            //     Success = true,
            //     Data = userCreated
            // });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception e)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        } 
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserViewModel userViewModel)
    {
        try
        {

            var userDto = _mapper.Map<UserDTO>(userViewModel);
            var userUpdated = await _userService.Update(userDto);
            return Ok(Responses.AplicationOkMessage("Usuario atualizado com sucesso.", userUpdated));
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception e)
        {
            // return StatusCode(500, Responses.ApplicationErrorMessage());
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _userService.Remove(id);
            
            return Ok(Responses.AplicationOkMessage("Usuario removido.", null));
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(long id)
    {
        try
        {
            var user = await _userService.Get(id);
            if (user != null)
            {
                return Ok(Responses.AplicationOkMessage("Usuario encontrado.", user));
            }
            else
            {
                return BadRequest(Responses.ApplicationErrorMessage("Usuario não encontrado", id));
            }
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }



    // [HttpGet]
    // public async Task<ActionResult<CreateUserViewModel>> Get()
    // {
    //     var usersDto = await _userService.Get();
    //     // var usersCreated = 
    //     return Ok(usersDto);
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<CreateUserViewModel>> GetByEmail(string email)
    // {
    //     try
    //     {
    //         var userDto = await _userService.GetByEmail(email);
    //         if (userDto != null)
    //         {
    //             return Ok(new ResultViewModel
    //             {
    //                 Message = "Usuario encontrado",
    //                 Success = true,
    //                 Data = userDto
    //             });
    //         }
    //         else
    //         {
    //             return NotFound(new ResultViewModel
    //             {
    //                 Message = "Usuario não encontrado",
    //                 Success = false,
    //                 Data = null
    //             });
    //             
    //         }
    //     }
    //     catch (DomainException e)
    //     {
    //         return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, Responses.ApplicationErrorMessage());            
    //     }
    //     
    // }

}