using CarFlowX.Application.Interfaces.TagCloudInterfaces;
using CarFlowX.Domain.Entities;
using CarFlowX.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarFlowXContext _context;

        public TagCloudRepository(CarFlowXContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}
