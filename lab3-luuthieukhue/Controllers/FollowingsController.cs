using lab3_luuthieukhue.DTOs;
using lab3_luuthieukhue.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab3_luuthieukhue.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Followings(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
            {
                return BadRequest("Following already exists!");
            }

            var follwing = new Following()
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId,
            };
            _dbContext.Followings.Add(follwing);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
