using SocialMedia.Models.ReplyModels;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24HourChallenge.WebAPI.Controllers
{
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var replyService = new ReplyService();
            return replyService;
        }

        // GET
        public IHttpActionResult Get()
        {
            var replyService = CreateReplyService();
            var replies = replyService.GetReplies();
            return Ok(replies);
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }

        //POST
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }

        //PUT (update)
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var replyService = CreateReplyService();

            if (!replyService.UpdateReply(reply))
                return InternalServerError();

            return Ok();
        }

        //DELTE
        public IHttpActionResult Delete(int id)
        {
            var replyService = CreateReplyService();

            if (!replyService.DeleteReply(id))
                return InternalServerError();

            return Ok();
        }
    }
}