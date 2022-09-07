using Microsoft.AspNetCore.Mvc;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class CountryController : BaseController<Country, Mongo.Entities.Country>
    {
        public CountryController(ICountryService baseService) : base(baseService)
        {
        }
    }
}
