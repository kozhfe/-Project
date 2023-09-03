using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Core;
using twoChapter.IServices;
using AutoMapper;
using twoChapter.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace twoChapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TestAPIController : ControllerBase
    { 
        public static IEnumerable<ITouristRouteRepository> _ap;

        private readonly IMapper _mapper;

        public TestAPIController(IEnumerable<ITouristRouteRepository> ap, IMapper mapper)
        {
            _ap = ap;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestAPI2Controller>/5
        [HttpGet("{TouristRouteId}")]
        public IActionResult Get(Guid TouristRouteId)
        {
            var lst = _ap.ToList().FirstOrDefault().GetTouristRoute(TouristRouteId);

            var todot = _mapper.Map<TouristRouteDto>(lst);

            return Ok(todot);
        }

        // POST api/<TestAPI2Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAPI2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAPI2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
