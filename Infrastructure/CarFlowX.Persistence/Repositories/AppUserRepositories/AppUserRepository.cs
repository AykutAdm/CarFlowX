using CarFlowX.Application.Interfaces.AppUserInterfaces;
using CarFlowX.Domain.Entities;
using CarFlowX.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarFlowXContext _context;

        public AppUserRepository(CarFlowXContext context)
        {
            _context = context;
        }

        public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
