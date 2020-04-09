using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
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
            Keep found = _repo.GetById(id);
            if(found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public IEnumerable<Keep> GetUserKeeps(string UserId)
        {
            return _repo.GetUserKeeps(UserId);
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        public Keep Update(Keep updatedKeep, string userId)
        {
            Keep exists = _repo.GetById(updatedKeep.Id);
            if(exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.Update(updatedKeep);
        }

        public bool Delete(int id, string userId)
        {
            return _repo.Delete(id, userId);
        }
    }
}