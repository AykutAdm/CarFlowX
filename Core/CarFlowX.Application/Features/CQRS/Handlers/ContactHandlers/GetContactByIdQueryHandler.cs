using CarFlowX.Application.Features.CQRS.Queries.ContactQueries;
using CarFlowX.Application.Features.CQRS.Results.ContactResults;
using CarFlowX.Application.Interfaces;
using CarFlowX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactId = values.ContactId,
                Name = values.Name,
                Email = values.Email,
                SendDate = values.SendDate,
                Message = values.Message,
                Subject = values.Subject
            };
        }
    }
}
