using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Dtos.Comment;
using DOTNETBACKEND.Models;

namespace DOTNETBACKEND.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(int id, Comment comment);
        Task<Comment?> UpdateCommentAsync(int id, CommentUpdateReqDto comment);
        Task<Comment?> DeleteCommentAsync(int id);
    }
}