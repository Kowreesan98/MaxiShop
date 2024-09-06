using MaxiShop.web.Data;
using MaxiShop.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MaxiShop.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult Get()
        {
            var categories = _dbContext.Category.ToList();

            return Ok(categories);
        } 
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [Route("Details")]
        public ActionResult Get(int Id)
        {
            var Category = _dbContext.Category.FirstOrDefault(x => x.Id == Id);

            if( Category == null)
            {
                return NotFound($"Category NotFound your given id : {Id}");
            }

            return Ok(Category);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]

        public ActionResult Create([FromBody]Category category)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);    
            }
            _dbContext.Category.Add(category);   //for store 
            _dbContext.SaveChanges();
            return Ok();
        }
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]

        public ActionResult Update([FromBody]Category category)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);    
            }
            _dbContext.Category.Update(category);  //for Update 
            _dbContext.SaveChanges();
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]

        public ActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest($"Invalid Input");
            }

            var category = _dbContext.Category.FirstOrDefault(x => x.Id == Id);

            if(category == null)
            {
                return NotFound($"This Id was not founded.");
            }
           
            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();   
            return NoContent();
        }

    }
}
