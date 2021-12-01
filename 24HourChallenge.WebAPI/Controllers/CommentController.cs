using SocialMedia.Models.CommentModels;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24HourChallenge.WebAPI.Controllers
{

    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var commentService = new CommentService();
            return commentService;
        }

        // GET
        public IHttpActionResult Get()
        {
            var commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok(comment);
        }

        //POST
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        //PUT (update)
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentService = CreateCommentService();

            if (!commentService.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        //DELTE
        public IHttpActionResult Delete(int id)
        {
            var commentService = CreateCommentService();

            if (!commentService.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }

    }
}