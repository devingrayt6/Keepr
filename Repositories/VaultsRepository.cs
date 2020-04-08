using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Vault> Get(string UserId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @UserId";
            return _db.Query<Vault>(sql, new { UserId });
        }

        public Vault GetById(int Id)
        {
            string sql = "Select * FROM vaults WHERE id = @Id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { Id });
        }

        internal Vault Create(Vault vaultData)
        {
            string sql = @"
            INSERT INTO vaults
            (userid, name, description)
            VALUES
            (@UserId, @Name, @Description);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }

        internal Vault Update(Vault vaultData)
        {
            string sql = @"
            UPDATE vaults
            SET
                id = @Id,
                name = @Name,
                description = @Description
            WHERE id = @Id
            ";
            _db.ExecuteScalar(sql, vaultData);
            return vaultData;
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM vaults WHERE id = @Id LIMIT 1";
            int success = _db.Execute(sql, new{ Id });
            return success == 1;
        }

        // VaultKeeps 

        internal IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
        {
            string sql = @"
            SELECT 
            k.*,
            vk.id as vaultKeepId
            FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = @vaultId AND vk.userId = @userId) 
            ";
            return _db.Query<Keep>(sql, new { vaultId, userId });
        }

        internal VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;
        }

        internal bool DeleteKeep(int Id)
        {
            string sql = @"
            DELETE FROM vaultkeeps WHERE id = @Id
            ";
            int success = _db.Execute(sql, new { Id });
            return success == 1;
        }
    }

}