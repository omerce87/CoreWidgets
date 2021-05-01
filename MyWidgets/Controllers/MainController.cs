using MainWidgets.AutoMappers;
using MainWidgets.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWidgets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public Customer GetValueByBlaBla()
        {
            Customer customer = new Customer {
                CreatedDate = DateTime.Now,
                CustomerAddress = "My Address",
                CustomerName = "Blabla",
                CustomerTel = "444",
                Id = 123,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now
            };
            CustomerFilterOne shortcustomer = new CustomerFilterOne {
                Id = 1,
                CustomerName = "Bla",
                CustomerTel = "555",
                CustomerAddress = "ISTANBUL"
            };
            
            return null;
        }
    }
}
