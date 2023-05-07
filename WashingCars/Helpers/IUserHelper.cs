﻿using Microsoft.AspNetCore.Identity;
using WashingCars.DAL.Entities;
using WashingCars.Models;

namespace WashingCars.Helpers
{
    public interface IUserHelper
    {
        #region method signatures
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel loginViewModel);

        Task LogoutAsync();

        #endregion
    }
}
