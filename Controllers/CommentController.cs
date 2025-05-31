using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNETBACKEND.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DOTNETBACKEND.Dtos.Comment;
using DOTNETBACKEND.Mappers;
using DOTNETBACKEND.Models;
using Microsoft.AspNetCore.Identity;
using DOTNETBACKEND.Extensions;

namespace DOTNETBACKEND.Controllers
{  
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public ICommentRepository _commentRepo;
        public IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comment = await _commentRepo.GetAllCommentsAsync();
            var commentDto = comment.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateComment([FromRoute] int id, [FromBody] CommentCreateReqDto commentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _stockRepo.StockExistsAsync(id))
            {
                return BadRequest("Stock does not exist");
            }
            if (commentDto == null)
            {
                return BadRequest("Comment data is required");
            }

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);


            var comment = commentDto.ToCommentFromCreateDto(id);
            comment.AppUserId = appUser.Id;
            var createdComment = await _commentRepo.CreateCommentAsync(id, comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment.ToCommentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] CommentUpdateReqDto commentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepo.UpdateCommentAsync(id, commentDto);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var comment = await _commentRepo.DeleteCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
    }
}