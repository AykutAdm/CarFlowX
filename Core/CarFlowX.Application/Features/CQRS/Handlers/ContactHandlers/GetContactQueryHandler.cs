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
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Subject = x.Subject,
                Email = x.Email,
                SendDate = x.SendDate,
                Message = x.Message
            }).ToList();
        }
    }
}