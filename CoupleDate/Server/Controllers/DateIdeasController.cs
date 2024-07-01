using CoupleDate.Server.Data.DataContext;
using CoupleDate.Server.Services.DateIdeaService;
using CoupleDate.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoupleDate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateIdeasController : ControllerBase
    {
        private readonly IDateIdeaService _dateIdeaService;

        public DateIdeasController(IDateIdeaService dateIdeaService)
        {
            _dateIdeaService = dateIdeaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DateIdea>>>> GetDateIdeas()
        {
            var response = await _dateIdeaService.GetDateIdeasAsync();
            return Ok(response);
        }
    }



}
