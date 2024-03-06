using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace SpecificationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.GetById(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetStores());
        }
        [HttpPost]
        public IActionResult Add(Store model)
        {
            if (ModelState.IsValid)
                return Created("", service.AddStore(model));
            else
                return BadRequest(model);
        }
        [HttpPut]
        public IActionResult Update(Store model)
        {
            if (ModelState.IsValid)
                return Ok(service.UpdateStore(model));
            else
                return BadRequest(model);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                service.RemoveStore(id);
                return NoContent();
            }
            else
                return NotFound(id);
        }
    }
}
