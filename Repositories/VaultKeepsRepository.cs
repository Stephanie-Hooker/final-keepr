using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using final_keepr.Models;

namespace final_keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<VaultKeep> Get(int vaultId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk 
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE(vaultId = @vaultId AND vk.userId = @userId)";
      var test = _db.Query<VaultKeep>(sql, new { vaultId, userId });
      return test;
    }

    public int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (userId, vaultId, keepId)
        VALUES
        (@UserId, @VaultId, @KeepId);
        SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    public void Delete(VaultKeep vaultKeep)
    {
      string sql = @"DELETE FROM vaultKeeps
      WHERE(vaultId = @vaultId AND keepId = @keepId AND userId = @userId)";
      _db.Execute(sql, new { vaultKeep.VaultId, vaultKeep.KeepId, vaultKeep.UserId });
    }
  }
}