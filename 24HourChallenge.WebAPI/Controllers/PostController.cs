using Microsoft.AspNet.Identity;
using SocialMedia.Models.PostModels;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24HourChallenge.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }

        //Get
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        //Post
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();
            return Ok();
        }

        //Put
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();
            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();
            if (!service.DeletePost(id))
                return InternalServerError();
            return Ok();
        }

    }
}