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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("{VaultId}")]
    public ActionResult<VaultKeep> Get(int vaultId, string userId)
    {
      try
      {
        return Ok(_vks.Get(vaultId, userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        newVaultKeep.UserId = userId;
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut]
    public ActionResult<VaultKeep> Edit([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        return Ok(_vks.Delete(vaultKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}