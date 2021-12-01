using SocialMedia.Data;
using SocialMedia.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        //Create
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                OwnerId = _userId,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now,
                CommentId = model.CommentId

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Read
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == id && e.OwnerId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        //Update
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.OwnerId == _userId);
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteUpdate(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.OwnerId == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
