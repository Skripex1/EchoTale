using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<RegisterUserRequestDto> _validator;

    public UserServices(IUserRepository repository, IMapper mapper,
        IValidator<RegisterUserRequestDto> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UserResponseDto> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto)
    {
        var validationResult = await _validator.ValidateAsync(registerUserRequestDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        bool isEmailUnique = await _repository.IsEmailUniqueAsync(registerUserRequestDto.Email);
        if (!isEmailUnique)
        {
            throw new ApplicationException("Username is already taken.");
        }

        bool isUsernameUnique = await _repository.IsUsernameUniqueAsync(registerUserRequestDto.Username);
        if (!isUsernameUnique)
        {
            throw new ApplicationException("Email is already taken.");
        }

        var user = _mapper.Map<User>(registerUserRequestDto);

        user.Id = Guid.NewGuid();

        await _repository.AddAsync(user);

        var reposneDto = _mapper.Map<UserResponseDto>(user);
        return reposneDto;
    }
}