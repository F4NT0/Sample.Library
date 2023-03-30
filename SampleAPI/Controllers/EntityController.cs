using Microsoft.AspNetCore.Mvc;
using SampleAPI.Infrastructure;
using SampleAPI.Models;
using System.Net;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController: ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;
        public EntityController(ILogger<EntityController> logger, IRepository repository) 
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var value = _repository.GetAll();
                if (value == null)
                {
                    return NotFound();
                }
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(String id) 
        {
            try
            {
                var value = _repository.Get(id);
                if (value == null)
                {
                    return NotFound();
                }
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("query")]
        public ActionResult GetByName([FromQuery]String name)
        {
            try
            {
                var value = (from r in _repository.Query() where r.Name.Equals(name,StringComparison.OrdinalIgnoreCase) select r).FirstOrDefault();
                if (value == null)
                {
                    return NotFound();
                }
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("query2")]
        public ActionResult GetByName2([FromQuery] String name)
        {
            try
            {
                var value = _repository.Query().Where(r =>  r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (value == null)
                {
                    return NotFound();
                }
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] SampleAPI.Models.Entity entity)
        {
            try
            {
                var value = _repository.Insert(entity);
                if (!value)
                {
                    return BadRequest("Could not insert the value");
                }
                return Created("", entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] SampleAPI.Models.Entity entity)
        {
            try
            {
                var value = _repository.Update(entity);
                if (!value)
                {
                    return BadRequest("Could not update the value");
                }
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            try
            {
                var value = _repository.Delete(new Entity() { Id = id});
                if (!value)
                {
                    return BadRequest("Could not update the value");
                }
                return StatusCode((int)HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
