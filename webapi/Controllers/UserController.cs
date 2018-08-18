using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.models;
using dal.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using repository;
using service.interfaces;


namespace webapi.Controllers
{
    
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private ILogger _logger;
        private IUserLogic _logic;
        public UserController(ILogger<UserController> logger, IUserLogic logic)
        {
                _logger = logger;
                _logic = logic;
        }

        //GET api/values
        [HttpGet]
        [Authorize(Roles="Admin")]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
        public async Task<IActionResult> Get()
        {
        
            try
            {
               
                var list = await _logic.GetAll();
                if(list == null)
                {
                    _logger.LogWarning("Not Found");
                    return NotFound();
                }
                _logger.LogInformation("SUCCESS");
                return Ok(list);
   
            }catch(Exception ex)
            {
                _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
        }


        // GET api/values/5
        [Authorize(Roles="Admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               
                var pet  = await _logic.GetByIDAsync(id);
                if(pet == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("SUCCESS");
                return Ok(pet);

            }catch(Exception ex)
            {
                _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
        }

        // POST api/values
        [Authorize(Roles="Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(SysUserDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string,string>), 400)]
        public async Task<IActionResult> Post([FromBody]SysUserDto viewmodel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   
                    await _logic.Create(viewmodel);
                    _logger.LogInformation("Success: Created");
                    return Ok();
                }
                else
                {
                     _logger.LogError("ERROR: Model State not Valid");
                    return BadRequest(ModelState);
                }
            }catch(Exception ex)
            {
                _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
            
           
        }

        [Authorize(Roles="Client,Admin")]
        [HttpPost("ChangePassword")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string,string>), 400)]
        public async Task<IActionResult> Post([FromBody]changePasswordReq viewmodel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                   
                    var resp = await _logic.UpdatePassword(viewmodel);
                    if(resp != null)
                    {
                        _logger.LogInformation("Success: Created");
                        return Ok();
                    }
                    else
                    {
                        _logger.LogWarning("Warning: Username Not Found");
                        return NotFound();
                    }
                    
                }
                else
                {
                     _logger.LogError("ERROR: Model State not Valid");
                    return BadRequest(ModelState);
                }
            }catch(Exception ex)
            {
                _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
            
           
        }

        [Authorize(Roles="Client,Admin")]
         // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(updateUserReq), 201)]
        [ProducesResponseType(typeof(IDictionary<string,string>), 400)]
        public async Task<IActionResult> Put(int id, [FromBody]updateUserReq viewmodel)
        {

            try
            {   
                if(ModelState.IsValid)
                {
                    viewmodel.Id = id;
                    viewmodel.address.Id = id;
                     await _logic.Update(viewmodel);
                     _logger.LogInformation("SUCCESS");
                    return Ok(viewmodel);
                }
                else
                {
                     _logger.LogError("ERROR: Model State not Valid");
                    return BadRequest(ModelState);
                }

            }catch(Exception ex)
            {
                 _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
        }


        [Authorize(Roles="Admin")]
         // PUT api/values/5
        [HttpPut("DeactivateUser/{id}")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(typeof(IDictionary<string,string>), 400)]
        public async Task<IActionResult> Put(int id)
        {

            try
            {   
                if(ModelState.IsValid)
                {
                    
                    await _logic.DeActivateUser(id);
                    _logger.LogInformation("SUCCESS: Successfully Deactivated User: "+ id);
                    return Ok(id);

                }
                else
                {
                     _logger.LogError("ERROR: Model State not Valid");
                    return BadRequest(ModelState);
                }

            }catch(Exception ex)
            {
                 _logger.LogCritical("ERROR: Info: "+ex.ToString());
                return StatusCode(500);
            }
        }

        [Authorize(Roles="Admin")]
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id > 0)
            {
                _logger.LogInformation("SUCCESSFULLY DELETED: "+id);
                await _logic.Delete(id);
                return Ok(id);
            }
            else{
                 _logger.LogError("ERROR: Not Found");
                return NotFound();
            }
            
        }
    }
}
