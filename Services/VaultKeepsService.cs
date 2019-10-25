using System;
using System.Collections.Generic;
using final_keepr.Models;
using final_keepr.Repositories;

namespace final_keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get(int vaultId, string userId)
    {
      return _repo.Get(vaultId, userId);
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public string Delete(VaultKeep vaultKeep)
    {
      if (vaultKeep == null) { throw new Exception("invalid"); }
      _repo.Delete(vaultKeep);
      return "successfully deleted";
    }
  }
}