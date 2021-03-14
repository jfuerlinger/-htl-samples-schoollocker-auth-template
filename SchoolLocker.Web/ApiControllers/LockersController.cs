
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SchoolLocker.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get Details to a locker.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Unauthorized</response>
        [HttpGet("{lockerNr}")]
        public Task<ActionResult> GetLockerDetails(int lockerNr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists all existing lockers.
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        public Task<ActionResult<int[]>> GetLockerNumbers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a new locker.
        /// </summary>
        /// <response code="201">The locker was created</response>
        /// <response code="400">Invalid parameters</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="409">The locker already exists</response>
        [HttpPost]
        public Task<ActionResult> AddLocker(int lockerNr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a locker.
        /// </summary>
        /// <response code="204">The locker was removed</response>
        /// <response code="400">Invalid Parameters</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">The locker does not exist</response>
        [HttpDelete]
        public Task<ActionResult> DeleteLocker(int lockerNr)
        {
            throw new NotImplementedException();
        }

    }
}
