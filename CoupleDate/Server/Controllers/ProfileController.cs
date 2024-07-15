using CoupleDate.Server.Services.ProfileService;
using CoupleDate.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoupleDate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _profileService.GetProfile();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpGet("partner")]
        public async Task<IActionResult> GetPartnerProfile()
        {
            var partner = await _profileService.GetPartnerProfile();
            if (partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] User updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest();
            }

            var result = await _profileService.UpdateProfile(updatedUser);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
