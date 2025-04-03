using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
    

       
            [HttpGet("GetPeople")]
            public IActionResult GetPeople()
            {
                var people = new List<Person>
            {
                new Person { Id = 1, Name = "علی", Age = 30 },
                new Person { Id = 2, Name = "رضا", Age = 25 }
            };
                return Ok(new { Result = "OK", Records = people });
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }


