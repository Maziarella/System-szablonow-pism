﻿using DAL.Models;
using DTS.API.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DTS.Auth.Services
{
    public interface IAuthServiceWrapper
    {
        IQueryHandlerAsync<LoginQuery, User> Login { get; }
        ICommandHandlerAsync<SignInCommand> SignIn { get; }
        ICommandHandlerAsync<ChangeUserLoginAndPasswordCommand> ChangeUserLoginAndPassword { get; }
    }
}
