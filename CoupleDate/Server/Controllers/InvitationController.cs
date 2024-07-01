﻿using CoupleDate.Server.Data.DataContext;
using CoupleDate.Server.Services.AuthService;
using CoupleDate.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoupleDate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationController : ControllerBase
    {
        private readonly DatingDbContext _context;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public InvitationController(DatingDbContext context, IAuthService authService, IConfiguration configuration)
        {
            _context = context;
            _authService = authService;
            _configuration = configuration;
        }

        [HttpGet("GenerateLink")]
        public async Task<IActionResult> GenerateLink()
        {
            var userId = _authService.GetUserId();
            var token = Guid.NewGuid().ToString();
            var invitation = new Invitation
            {
                UserId = userId,
                Token = token,
                Expiration = DateTime.Now.AddDays(7) // Link valid for 7 days
            };

            _context.Invitations.Add(invitation);
            await _context.SaveChangesAsync();

            var link = $"{_configuration["AppUrl"]}/accept-invitation?token={token}";
            return Ok(link);
        }

        [HttpGet("AcceptInvitation")]
        public async Task<IActionResult> AcceptInvitation(string token)
        {
            var invitation = await _context.Invitations
                .FirstOrDefaultAsync(i => i.Token == token && i.Expiration > DateTime.Now);

            if (invitation == null)
                return BadRequest("Invalid or expired token.");

            var invitingUser = await _context.Users.FindAsync(invitation.UserId);
            var acceptingUserId = _authService.GetUserId();
            var acceptingUser = await _context.Users.FindAsync(acceptingUserId);

            if (invitingUser == null || acceptingUser == null)
                return NotFound("User not found.");

            if (invitingUser.CoupleId == null)
            {
                var coupleId = new Random().Next(1, int.MaxValue); // Generate random coupleId
                invitingUser.CoupleId = coupleId;
                acceptingUser.CoupleId = coupleId;
            }
            else
            {
                acceptingUser.CoupleId = invitingUser.CoupleId;
            }

            await _context.SaveChangesAsync();
            return Ok("Invitation accepted. You are now connected as a couple.");
        }
    }


}