using Microsoft.AspNetCore.Mvc;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class ExchangeRateController : BaseController<ExchangeRate, Mongo.Entities.ExchangeRate>
    {
        public ExchangeRateController(IBaseService<ExchangeRate, Mongo.Entities.ExchangeRate> baseService) : base(baseService)
        {
        }
    }
}
