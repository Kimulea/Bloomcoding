using Domain;
using MediatR;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Features.FreeHourFeatures.Commands
{
    public class CreateFreeHourCommand : IRequest<FreeHour>
    {
        public DateTime HourMinute { get; set; }
        public DateTime DayOfWeek { get; set; }
        public int UserId { get; set; }

        public class CreateFreeHourCommandHandler : IRequestHandler<CreateFreeHourCommand, FreeHour>
        {
            private readonly IGenericRepository<FreeHour> _repository;

            public CreateFreeHourCommandHandler(IGenericRepository<FreeHour> repository)
            {
                _repository = repository;
            }

            public async Task<FreeHour> Handle(CreateFreeHourCommand request, CancellationToken cancellationToken)
            {
                var freeHour = new FreeHour
                {
                    HourMinute = request.HourMinute,
                    DayOfWeek = request.DayOfWeek,
                    UserId = request.UserId
            };

                await _repository.Add(freeHour);

                return freeHour;
            }
        }
    }
}
