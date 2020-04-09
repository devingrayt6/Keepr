using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/")]
    public class VaultsController:ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }

        [HttpGet("[controller]")]
        [Authorize]

        public IEnumerable<Vault> Get()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _vs.Get(userId);
        }

        [HttpGet("[controller]/{id}")]
        [Authorize]
        public ActionResult<Vault> GetById(int id)
        {
            return _vs.GetById(id);
        }

        [HttpPost("[controller]")]
        [Authorize]

        public ActionResult<Vault> Create([FromBody] Vault vaultData)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                vaultData.UserId = userId;
                return Ok(_vs.Create(vaultData));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [HttpPut("[controller]/{id}")]
        [Authorize]

        public ActionResult<Vault> Update(int id, [FromBody] Vault newVault)
        {
            try
            {
                newVault.Id = id;
                return Ok(_vs.Update(newVault));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("[controller]/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_vs.Delete(id));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }


        // VaultsKeeps Controlls

        [HttpGet("vaultkeeps")]
        [Authorize]

        public IEnumerable<VaultKeep> GetAllVaultKeeps()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _vs.GetAllVaultKeeps(userId);
        }

        [HttpGet("[controller]/{vaultId}/keeps")]
        [Authorize]

        public IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
        {
             var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _vs.GetVaultKeeps(vaultId, userId);
        }

        [HttpPost("vaultkeeps")]
        [Authorize]
        public ActionResult<VaultKeep> CreateVaultKeep([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVaultKeep.UserId = userId;
                return Ok(_vs.CreateVaultKeep(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("vaultkeeps/{id}")]
        public ActionResult<bool> DeleteKeep(int id)
        {
            try
            {
                return Ok(_vs.DeleteKeep(id));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}