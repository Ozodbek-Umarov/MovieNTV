﻿using Application.DTOs.UserDtos;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<bool> RegistrAsync(AddUserDto dto);
    Task<string> LoginAsync(LoginDto login);
}
