using CarFlowX.Application.Interfaces.ReviewInterfaces;
using CarFlowX.Domain.Entities;
using CarFlowX.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarFlowXContext _context;

        public ReviewRepository(CarFlowXContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByCarId(int carId)
        {
            var values = _context.Reviews.Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}
