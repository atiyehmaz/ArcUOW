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
using System.Web.Http.Cors;


namespace WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*",SupportsCredentials =true)]
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
        [HttpOptions]
        [Route("api/Customer/GetCustomers")]
        public IHttpActionResult GetCustomers()

        {
            var list = _customerService.GetAll();
            return Ok(list);
        }

        [HttpPost]
        [Route("api/Customer/CreateCustomer")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpGet]
        [HttpOptions]
        [Route("api/Customer/DeleteCustomer")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id != 0)
            {
                try
                {
                    _unitOfWork.CreateTransaction();
                    _customerService.Delete(id);
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
