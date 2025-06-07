using Application.Features.MediatR.Users.Commands;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IUserFactory
    {
        Task<User> CreateUserAsync(CreateUserCommand request);
    }
}
