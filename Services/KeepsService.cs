using System;
using System.Collections.Generic;
using final_keepr.Models;
using final_keepr.Repositories;

namespace final_keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep GetById(int id)
    {
      Keep exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid id"); }
      return exists;
    }

    public IEnumerable<Keep> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }

    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;

    }

    public Keep Edit(Keep newKeep)
    {
      Keep keep = _repo.GetById(newKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Name = newKeep.Name;
      keep.Description = newKeep.Description;
      keep.Img = newKeep.Img;
      keep.IsPrivate = newKeep.IsPrivate;
      keep.Views = newKeep.Views;
      keep.Keeps = newKeep.Keeps;
      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep keep = _repo.GetById(id);
      if (keep == null) { throw new Exception("invalid id"); }
      _repo.Delete(id);
      return "Keep deleted";

    }
  }
}