using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var vv=_commentContext.UserComments.ToList();
            return Ok(vv);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment comment)
        {
            _commentContext.UserComments.Add(comment);
            _commentContext.SaveChanges();
            return Ok(" eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment comment)
        {
            _commentContext.UserComments.Update(comment);
            _commentContext.SaveChanges();
            return Ok("güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var vv=_commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(vv);
            _commentContext.SaveChanges();
            return Ok("silindi");
        }
        [HttpGet("GetById")]
        public IActionResult GetCommentById(int id)
        {
            var vv = _commentContext.UserComments.Find(id);
            return Ok(vv);
        }
        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var vv = _commentContext.UserComments.Where(x=>x.ProductId == id).ToList();
            return Ok(vv);
        }
    }
}
