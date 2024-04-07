﻿using GeorgeShopAndRecipe.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GeorgeShopAndRecipe.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }

        [HttpGet]

        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();

            return Ok(result);
        }
    }
}
