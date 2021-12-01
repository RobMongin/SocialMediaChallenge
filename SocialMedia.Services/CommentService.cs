using SocialMedia.Data;
using SocialMedia.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentId = model.CommentId,
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Content = e.Content
                                }
                        );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Content = entity.Content
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId);
                entity.Content = model.Content;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}