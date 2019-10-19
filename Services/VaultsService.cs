using System;
using System.Collections.Generic;
using final_keepr.Models;
using final_keepr.Repositories;

namespace final_keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public Vault Create(Vault newVault)
    {
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    public IEnumerable<Vault> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }

    public Vault GetById(int vaultId)
    {
      Vault exists = _repo.GetById(vaultId);
      if (exists == null) { throw new Exception("Invalid id"); }
      return exists;
    }

    public string Delete(int vaultId)
    {
      Vault exists = _repo.GetById(vaultId);
      if (exists == null) { throw new Exception("invalid id"); }
      _repo.Delete(vaultId);
      return "Vault Deleted";
    }
  }
}