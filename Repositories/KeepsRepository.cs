using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using final_keepr.Models;

namespace final_keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    // return all keeps
    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    // return one keep that matches keep id
    public Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    // return all keeps by UserId
    public IEnumerable<Keep> GetByUser(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    // creates new keep and returns keepId
    public int Create(Keep newKeep)
    {
      string sql = @"
     INSERT INTO keeps
     (name, userId, description, img, isPrivate)
     VALUES
     (@Name, @UserId, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    public void Edit(Keep keep)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img,
      isPrivate = @IsPrivate,
      views = @Views,
      shares = @Shares,
      keeps = @Keeps
      WHERE id = @Id
      ";
      _db.Execute(sql, keep);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}