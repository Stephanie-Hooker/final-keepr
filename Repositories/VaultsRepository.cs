using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using final_keepr.Models;

namespace final_keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> GetByUser(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    public int Create(Vault newVault)
    {
      string sql = @"
        INSERT INTO vaults
        (userId, name, description)
        VALUES
        (@UserId, @Name, @Description);
        SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public Vault GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}