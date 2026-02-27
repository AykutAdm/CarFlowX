using CarFlowX.Application.Features.RepositoryPattern;
using CarFlowX.Domain.Entities;
using CarFlowX.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarFlowXContext _context;

        public CommentRepository(CarFlowXContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();
        }

        public int GetCountCommentByBlog(int id)
        {
            return _context.Comments.Where(x => x.BlogId == id).Count();
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentId);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
