using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Domain;
using Data;
using Service;
using Service.BaseService;
using System.Web.Http.Cors;


namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*", SupportsCredentials = true)]
    public class DepositController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDepositService _depositService;

        public DepositController(IUnitOfWork unitOfWork, IDepositService depositService)
        {
            this._unitOfWork = unitOfWork;
            this._depositService = depositService;

        }

        [HttpGet]
        [HttpOptions]
        [Route("api/Deposit/GetDeposits")]
        public IHttpActionResult GetDeposits()

        {
            var list = _depositService.GetAll();
            return Ok(list);
        }


        [HttpPost]
        [Route("api/Deposit/CreateDeposit")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult CreateDeposit([FromBody]Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CreateTransaction();
                    _depositService.Insert(deposit);
                    _unitOfWork.Save();
                    _unitOfWork.Commit();
                    if (_unitOfWork.Successful == true)
                    {
                        return Ok();
                    }

                }
                catch (Exception)
                {

                    _unitOfWork.Rollback();
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        [HttpGet]
        [HttpOptions]
        [Route("api/Deposit/DeleteDeposit")]
        public IHttpActionResult DeleteDeposit(int id)
        {
            if (id != 0)
            {
                try
                {
                    _unitOfWork.CreateTransaction();
                    _depositService.Delete(id);
                    _unitOfWork.Save();
                    _unitOfWork.Commit();
                    if (_unitOfWork.Successful == true)
                    {
                        return Ok();
                    }
                }
                catch (Exception)
                {
                    _unitOfWork.Rollback();
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}