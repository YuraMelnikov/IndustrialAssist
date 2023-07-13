﻿using ErrorOr;
using IndustrialAssist.Application.Services.Authentication.Common;

namespace IndustrialAssist.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}