using CarFlowX.Application.Features.Mediator.Queries.BlogQueries;
using CarFlowX.Application.Features.Mediator.Results.BlogResults;
using CarFlowX.Application.Interfaces;
using CarFlowX.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = values.BlogId,
                Title = values.Title,
                CoverImageUrl = values.CoverImageUrl,
                CreatedDate = values.CreatedDate,
                AuthorId = values.AuthorId,
                CategoryId = values.CategoryId
            };
        }
    }
}

