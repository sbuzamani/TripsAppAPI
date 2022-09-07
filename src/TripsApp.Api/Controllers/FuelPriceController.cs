using Microsoft.AspNetCore.Mvc;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelPriceController : BaseController<FuelPrice, Mongo.Entities.FuelPrice>
    {
        public FuelPriceController(IFuelPriceService FuelPriceService) : base(FuelPriceService)
        {
        }
    }
}
