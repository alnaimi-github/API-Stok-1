using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;

namespace API.Interfaces.Repository
{
    public class CommentRepository : ICommentRepository
    {
          private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Comment> CreateAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Task.FromResult(comment);
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment=await GetById(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return await Task.FromResult(comment);
            }
            return await Task.FromResult<Comment?>(null);
            
        }

        public Task<List<Comment>> GetAllAsync()
        {
           return Task.FromResult(_context.Comments.ToList());
        }

        public Task<Comment?> GetById(int id)
        {
            var comment = _context.Comments.Find(id);
            return Task.FromResult(comment);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
           
            var commentToUpdate = await GetById(id);
            if (commentToUpdate != null)
            {
                commentToUpdate.Title = comment.Title;
                commentToUpdate.Content = comment.Content;
                _context.SaveChanges();
                return await Task.FromResult(commentToUpdate);
            }
            return await Task.FromResult<Comment?>(null);
        }
    }
}