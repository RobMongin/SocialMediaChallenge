using SocialMedia.Data;
using SocialMedia.Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    ReplyId = model.ReplyId,
                    ReplyName = model.ReplyName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    ReplyName = e.ReplyName
                                }
                        );
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == replyId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        ReplyName = entity.ReplyName
                    };
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == model.ReplyId);
                entity.ReplyName = model.ReplyName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyId == replyId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}