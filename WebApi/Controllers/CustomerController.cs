using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Data;
using Service;
using Service.BaseService;

namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICustomerService _customerService;

        public CustomerController(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            this._unitOfWork = unitOfWork;
            this._customerService = customerService;
        }

        [HttpGet]
        [Route("api/Customer/GetCustomers")]
        public IHttpActionResult GetCustomers()

        {
            var list = _customerService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        [Route("api/Customer/CreateCustomer")]
        public IHttpActionResult CreateCustomer([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CreateTransaction();
                    _customerService.Insert(customer);
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
