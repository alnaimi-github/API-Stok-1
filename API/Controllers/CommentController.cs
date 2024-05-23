using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Comment;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

       private readonly  IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var commentsDto = (await _commentRepository.GetAllAsync()).Select(c => c.ToCommentDto());
            return Ok(commentsDto); 
       }
           
            [HttpGet("{id}")]
            public async Task<IActionResult> GetComment(int id)
            {
                var comment = await _commentRepository.GetById(id);
                if (comment == null)
                {
                    return NotFound();
                }
                return Ok(comment.ToCommentDto());
            }
         [HttpPost("{stockId}")]
        public async Task<IActionResult> CreateComment(int stockId,[FromBody] CreateCommentDto requestDto)
        {
            if(!await _stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var comment = requestDto.ToCommentCreate(stockId);
            await _commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetComment), new {id = comment.Id}, comment.ToCommentDto());
        }   

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CreateCommentDto requestDto)
        {
           
             var comment =  await _commentRepository.UpdateAsync(id,requestDto.ToCommentUpdate());
            if (comment == null)
            {
                return NotFound("Comment does not exist");
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment =await _commentRepository.DeleteAsync(id);
            if (comment == null)
            {
                return NotFound("Comment does not exist");
            }
         
            return Ok(comment.ToCommentDto());
        }

    }
}