using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SingUpAsync(SignUpModel signUpModel);
        Task<string> LogInAsync(SignInModel signInModel);
    }
}
