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

        public Vault GetById(int Id)
        {
            return _repo.GetById(Id);
        }

        public Vault Create(Vault vaultData)
        {
            return _repo.Create(vaultData);
        }

        public Vault Update(Vault newVault)
        {
            Vault exists = _repo.GetById(newVault.Id);
            if(exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Update(newVault);
        }

        public bool Delete(int Id)
        {
            return _repo.Delete(Id);
        }

        // VaultKeeps

        public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
        {
            return _repo.GetVaultKeeps(vaultId, userId);
        }

        public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
        {
            return _repo.CreateVaultKeep(newVaultKeep);
        }

        public bool DeleteKeep(int id)
        {
            return _repo.DeleteKeep(id);
        }
    }
}