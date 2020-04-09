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

        public ActionResult<IEnumerable<Vault>> Get()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_vs.Get(userId));
        }

        [HttpGet("[controller]/{id}")]
        [Authorize]
        public ActionResult<Vault> GetById(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.GetById(id, userId));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
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
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVault.Id = id;
                return Ok(_vs.Update(newVault, userId));
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
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.Delete(id, userId));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }


        // VaultsKeeps Controlls

        [HttpGet("vaultkeeps")]
        [Authorize]

        public ActionResult<IEnumerable<VaultKeep>> GetAllVaultKeeps()
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_vs.GetAllVaultKeeps(userId));
            
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpGet("[controller]/{vaultId}/keeps")]
        [Authorize]

        public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int vaultId)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_vs.GetVaultKeeps(vaultId, userId));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
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
        public ActionResult<bool> DeleteVaultKeep(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vs.DeleteVaultKeep(id, userId));
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);            }
        }

    }
}