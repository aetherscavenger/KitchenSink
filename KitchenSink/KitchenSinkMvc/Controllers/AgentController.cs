using KitchenSink.Core.DataAccessor;
using KitchenSinkMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KitchenSinkMvc.Controllers
{
	public class AgentController : Controller
	{
		private IDataAccessor _dataAccessor;

		public AgentController(IDataAccessor dataAccessor)
		{
			_dataAccessor = dataAccessor;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetCustomers(Agent agent)
		{
			var parameters = new Dictionary<string, object>();
			parameters.Add("agentId", agent._id);
			var data = _dataAccessor.Read<AgentCustomer>(parameters);
			return Json(data);
		}
		public IActionResult GetData()
		{
			var data = _dataAccessor.Read<Agent>();
			return Json(data);
		}
		[HttpPost]
		public IActionResult SaveData(Agent saveMe)
		{
			var result = _dataAccessor.Write<Agent>(saveMe, null);
			return Json(result.Payload);
		}
	}
}