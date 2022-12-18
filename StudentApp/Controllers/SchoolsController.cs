using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Models;
using StudentApp.Data.VM;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            //Note: Merren te dhenat nga databaza
            var allSchools = new List<School>()
            {
                new School()
                {
                    Id = 1,
                    Name = "School 1",
                    Address = "Address 1",
                    YearEstablished = 2000
                },
                new School()
                {
                    Id = 2,
                    Name = "School 2",
                    Address = "Address 2",
                    YearEstablished = 2001
                }
            };

            return Ok(allSchools);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //NOTE: Merret vetem nje shkolle nga databaza me id
            var school = new School()
            {
                Id = 1,
                Name = "School 1",
                Address = "Address 1",
                YearEstablished = 2000
            };

            return Ok(school);
        }


        [HttpPost]
        public IActionResult AddSchool([FromBody] SchoolVM schoolVM)
        {
            //Krijohet objekti shkolle
            var school = new School()
            {
                //Id = Gjenerohet nga database
                Name = schoolVM.Name,
                Address = schoolVM.Address,
                YearEstablished = schoolVM.YearEstablished,

                //Mund te jene edhe ne nivel database
                DateCreated = DateTime.UtcNow,
                DateUpdated = null
            };

            //Objekti i krijuar shtohet ne databaze me Entity Framework
            return Created("", school);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchool([FromBody]SchoolVM schoolVM, int id)
        {
            //Merret objekti School nga database duket perdorur Id si parameter
            var school = new School()
            {
                Id = 1,
                Name = "Univesiteti Beder",
                Address = "Address 1",
                YearEstablished = 2000
            };


            //Modifikohet objekti School i marre nga databaza duket perdorur te dhenat nga FromBody
            school.Name = schoolVM.Name;
            school.Address = schoolVM.Address;
            school.YearEstablished = schoolVM.YearEstablished;
            school.DateUpdated = DateTime.UtcNow;

            //Perditesohet objekti shkolle ne database me Entity Framework

            return Ok($"School with id = {id} was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            //NOTE: Kalohet Id si parameter dhe fshihet Shkolla nga databaza

            return Ok($"School with id {id} deleted");
        }


    }
}
