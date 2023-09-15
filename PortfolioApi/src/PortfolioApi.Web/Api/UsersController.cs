using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortfolioApi.Core.model;
using PortfolioApi.SharedKernel.Interfaces;
using PortfolioApi.Web.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioApi.Web.Api;
[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseApiController
{
  private readonly IRepository<Users> _userRepository;
  public UsersController(IRepository<Users> userrepository)
  {
    _userRepository = userrepository;
  }
  // GET: api/<UsersController>
  [HttpGet]
  public async Task<JsonResult> Get()
  {
    try {
      var userDetails = await _userRepository.ListAsync();
      return Json(JsonConvert.SerializeObject(userDetails));
    }
    catch (Exception ex)
    {
      return Json(JsonConvert.SerializeObject(ex.Message));
    }
    
    
  }

  // GET api/<UsersController>/5
  [HttpGet("{id}")]
  public string Get(int id)
  {
    return "value";
  }

  // POST api/<UsersController>
  [HttpPost]
  public async Task<JsonResult> Post([FromBody] UsersDto value)
  {
    try
    {
      Users user = new Users();
      user.FirstName = value.FirstName;
      user.LasttName = value.LasttName;
      user.Email = value.Email;
      user.Password = value.Password;
      user.Address = value.Address;

      await _userRepository.AddAsync(user);
      return Json(JsonConvert.SerializeObject(user));
    }
    catch (Exception ex)
    {
      return Json(JsonConvert.SerializeObject(ex.Message));
    }
  }

  // PUT api/<UsersController>/5
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value)
  {
  }

  // DELETE api/<UsersController>/5
  [HttpDelete("{id}")]
  public void Delete(int id)
  {
  }
}
