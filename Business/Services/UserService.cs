﻿using Business.Models;
using Business.ReturnType;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public interface IUserService
{
    Task<CreateUserResult> CreateUserAsync(SignUpForm form);
    Task<bool> UserAlreadyExists(string email);
}

public class UserService(UserManager<AppUserEntity> userManager) : IUserService
{
    private readonly UserManager<AppUserEntity> _userManager = userManager;

    public async Task<bool> UserAlreadyExists(string email) =>
        await _userManager.Users.AnyAsync(x => x.Email == email);

    public async Task<CreateUserResult> CreateUserAsync(SignUpForm form)
    {
        var user = new AppUserEntity
        {
            Email = form.Email,
            UserName = form.Email,
            FirstName = form.FirstName,
            LastName = form.LastName
        };
        var result = await _userManager.CreateAsync(user, form.Password);

        return new CreateUserResult
        {
            Success = result.Succeeded,
            Errors = result.Errors.Select(x => x.Description)
        };
    }
}
