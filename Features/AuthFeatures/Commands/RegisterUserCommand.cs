using BCrypt.Net;
using Domain;
using MediatR;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Features.AuthFeatures.Commands
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
        {
            private readonly IGenericRepository<User> _repository;

            public CreateUserCommandHandler(IGenericRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
                };

                await _repository.Add(user);

                return user;
            }
        }
    }
}
