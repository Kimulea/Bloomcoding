using Domain;
using MediatR;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bloomcoding.Features.AuthFeatures.Queries
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
        {
            private readonly IGenericRepository<User> _repository;

            public GetUserByEmailQueryHandler(IGenericRepository<User> repository)
            {
                _repository = repository;
            }
            public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                return await _repository.FirstOrDefault(p => p.Email == request.Email);
            }
        }
    }
}
