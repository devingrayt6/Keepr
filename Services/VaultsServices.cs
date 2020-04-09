using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Vault> Get(string userId)
        {
            return _repo.Get(userId);
        }

        public Vault GetById(int Id, string userId)
        {
            return _repo.GetById(Id, userId);
        }

        public Vault Create(Vault vaultData)
        {
            return _repo.Create(vaultData);
        }

        public Vault Update(Vault newVault, string userId)
        {
            Vault exists = _repo.GetById(newVault.Id, userId);
            if(exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Update(newVault, userId);
        }

        public bool Delete(int Id, string UserId)
        {
            return _repo.Delete(Id, UserId);
        }

        // VaultKeeps

        public IEnumerable<VaultKeep> GetAllVaultKeeps(string userId)
        {
            return _repo.GetAllVaultKeeps(userId);
        }
        public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
        {
            return _repo.GetVaultKeeps(vaultId, userId);
        }

        public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
        {
            return _repo.CreateVaultKeep(newVaultKeep);
        }

        public bool DeleteVaultKeep(int id, string userId)
        {
            return _repo.DeleteVaultKeep(id, userId);
        }
    }
}