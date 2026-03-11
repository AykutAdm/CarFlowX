using CarFlowX.Application.Features.Mediator.Commands.ReviewCommands;
using CarFlowX.Application.Interfaces;
using CarFlowX.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CustomerImage = request.CustomerImage,
                CarId = request.CarId,
                Comment = request.Comment,
                CustomerName = request.CustomerName,
                RatingValue = request.RatingValue,
                ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
            });
        }
    }
}
