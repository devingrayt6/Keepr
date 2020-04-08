using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        public Keep GetById(int Id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
        } 

        internal Keep Create(Keep KeepData)
        {
            string sql = @"
            INSERT INTO keeps
            (userid, name, description, img, isPrivate, views, shares, keeps)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, KeepData);
            KeepData.Id = id;
            return KeepData;
        }

        internal Keep Update(Keep KeepData)
        {
            string sql = @"
            UPDATE keeps
            SET
                id = @Id,
                name = @Name,
                description = @Description,
                img = @Img,
                isPrivate = @IsPrivate,
                views = @Views,
                shares = @Shares,
                keeps = @Keeps
            WHERE id = @Id
            ";
            _db.ExecuteScalar(sql, KeepData);
            return KeepData;
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
            int success = _db.Execute(sql, new{ Id });
            return success == 1;
        }

    }
}