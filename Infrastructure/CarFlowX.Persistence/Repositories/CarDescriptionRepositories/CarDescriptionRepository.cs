using CarFlowX.Application.Interfaces.CarDescriptionInterfaces;
using CarFlowX.Domain.Entities;
using CarFlowX.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarFlowXContext _context;

        public CarDescriptionRepository(CarFlowXContext context)
        {
            _context = context;
        }

        public async Task<CarDescription> GetCarDescription(int carId)
        {
            var values = await _context.CarDescriptions.Where(x => x.CarId == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
