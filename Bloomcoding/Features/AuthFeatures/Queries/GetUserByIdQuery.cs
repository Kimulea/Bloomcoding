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
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IGenericRepository<User> _repository;

            public GetUserByIdQueryHandler(IGenericRepository<User> repository)
            {
                _repository = repository;
            }
            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetById(request.Id);
            }
        }
    }
}
