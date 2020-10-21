﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlanner.Core.Triposo;
using TravelPlanner.Services;

namespace TravelPlanner.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TourInformationController : ControllerBase
    {
        private readonly TravelInfoService TravelInfoService;
        public TourInformationController()
        {
            TravelInfoService = new TravelInfoService();
        }

        [HttpGet]
        public Task<Tour[]> GetTourInformation(string locationIds, string poiId, string tagLabels)
        {
            return TravelInfoService.GetTourInformation(locationIds, poiId, tagLabels);
        }
    }
}
