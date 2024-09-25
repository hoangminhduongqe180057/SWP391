using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsManagement.Client.Repository;
using StudentsManagement.Data;
using StudentsManagement.Services;
using StudentsManagement.Shared.Models;

namespace StudentsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // private readonly ApplicationDbContext _context; , ApplicationDbContext context

        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
           // _context = context;
            _countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet("All-Countries")]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("Single-Country/{id}")]
        public async Task<ActionResult<Country>> GetSingleCountry(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Update-Country")]
        public async Task<ActionResult<Country>> UpdateAsync(Country country)
        {
            var updateCountry = await _countryRepository.UpdateAsync(country);

            return Ok(updateCountry);
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-Country")]
        public async Task<ActionResult<Student>> AddAsync(Country mod)
        {
            var newcountry = await _countryRepository.AddAsync(mod);

            return Ok(newcountry);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-Country/{id}")]
        public async Task<ActionResult<Country>> DeleteAsync(int id)
        {
            var deletecountry = await _countryRepository.DeleteAsync(id);

            return Ok(deletecountry);
        }

        //private bool CountryExists(int id)
        //{
        //    return _context.Countries.Any(e => e.Id == id);
        //}
    }
}
