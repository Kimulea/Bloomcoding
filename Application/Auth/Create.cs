using Domain;
using MediatR;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth
{
    public class Create
    {
        public class Command : IRequest<User>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly IGenericRepository<User> _repository;

            public Handler(IGenericRepository<User> repository)
            {
                _repository = repository;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = request.Password
                };

                await _repository.Add(user);

                return user;
            }
        }
    }
}
