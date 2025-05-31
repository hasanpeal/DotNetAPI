using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Dtos.Comment;
using DOTNETBACKEND.Models;

namespace DOTNETBACKEND.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment) // Dont forget this
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                CreatedBy = comment.CreatedBy,
                StockId = comment.StockId
            };
        }

        public static Comment ToCommentFromCreateDto(this CommentCreateReqDto commentCreateReqDto, int StockId)
        {
            return new Comment
            {
                Content = commentCreateReqDto.Content,
                StockId = StockId
            };
        }
    }
}