using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Customers;
using KitchenSink.Core.DataAccessor;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkMvc.Controllers
{
    public class CustomerController : Controller
    {
        private IDataAccessor _dataAccessor;

        public CustomerController(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        [HttpPost]
        public IActionResult SaveData(Customer saveMe)
        {
            var result = _dataAccessor.Write<Customer>(saveMe, null);
            return Json(result.Payload);
        }
        [HttpDelete]
        public IActionResult DeleteData(Customer deleteMe)
        {
            _dataAccessor.Delete<Customer>(deleteMe._id);
            return Json(new { complete = true });
        }
    }
}