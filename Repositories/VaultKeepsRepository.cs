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
    public IEnumerable<Keep> Get(int vaultId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk 
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE(vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId, userId });

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

    public VaultKeep Get(VaultKeep vaultKeep)
    {
      string sql = @"SELECT * FROM vaultkeeps WHERE vaultId = @VaultId AND userId = @UserId AND keepId = @KeepId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, vaultKeep);
    }

    public void Delete(int id)
    {
      string sql = @"DELETE FROM vaultKeeps
      WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}