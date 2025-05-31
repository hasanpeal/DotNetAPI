using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Data;
using DOTNETBACKEND.Dtos.Comment;
using DOTNETBACKEND.Interfaces;
using DOTNETBACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNETBACKEND.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync(int id, Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            var comment = await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        
        }

        public async Task<Comment?> UpdateCommentAsync(int id, CommentUpdateReqDto comment)
        {
            var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (commentToUpdate == null) return null;
            commentToUpdate.Content = comment.Content;
            await _context.SaveChangesAsync();
            return commentToUpdate;
        }
    }
}