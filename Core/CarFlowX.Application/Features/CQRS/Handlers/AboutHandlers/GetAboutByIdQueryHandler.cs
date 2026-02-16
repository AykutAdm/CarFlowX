using CarFlowX.Application.Features.CQRS.Queries.AboutQueries;
using CarFlowX.Application.Features.CQRS.Results.AboutResults;
using CarFlowX.Application.Interfaces;
using CarFlowX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Description = values.Description,
                Title = values.Title,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
