using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTLProject.Business.Abstract;

namespace RTLProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;

        public ShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetTvShow([FromQuery] int page = 1)
        {     
            int pageSize = 100;
            var tvShow = _tvShowService.GetTvShow(page, pageSize);
            if (tvShow.Success)
                return Ok(tvShow.Data);
           
            return BadRequest(tvShow.Message);
        }
    }
}
