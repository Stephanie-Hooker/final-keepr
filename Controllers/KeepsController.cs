using System;
using System.Collections.Generic;
using System.Security.Claims;
using final_keepr.Models;
using final_keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;


    public KeepsController(KeepsService ks)
    {
      _ks = ks;

    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{keepId}")]
    public ActionResult<Keep> GetById(int keepId)
    {
      try
      {
        return Ok(_ks.GetById(keepId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.GetByUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        newKeep.UserId = userId;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep newKeep, int id)
    {
      try
      {
        newKeep.Id = id;
        return Ok(_ks.Edit(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<int> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");

        return Ok(_ks.Delete(id, userId));

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}