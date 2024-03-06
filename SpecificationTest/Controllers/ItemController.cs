using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace SpecificationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetItems());
        }
        [HttpPost]
        public IActionResult Add(Item model)
        {
            if(ModelState.IsValid)
                return Created("", service.AddItem(model));
            else
                return BadRequest(model);
        }
        [HttpPut]
        public IActionResult Update(Item model)
        {
            if (ModelState.IsValid)
                return Ok(service.UpdateItem(model));
            else
                return BadRequest(model);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                service.RemoveItem(id);
                return NoContent();
            }
            else
                return NotFound(id);
        }
    }
}
