using System;
using System.Security.Claims;
using final_keepr.Models;
using final_keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<Vault> GetByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.GetByUser(userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{VaultId}")]
    public ActionResult<Vault> GetById(int vaultId)
    {
      try
      {
        return Ok(_vs.GetById(vaultId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault newVault)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        newVault.UserId = userId;
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{vaultId}")]
    public ActionResult<Vault> Delete(int vaultId)
    {
      try
      {
        // string userId = HttpContext.User.FindFirstValue("Id");

        return Ok(_vs.Delete(vaultId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}