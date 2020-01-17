using KitchenSink.Core.DataAccessor;
using KitchenSinkMvc.Models;
using Microsoft.AspNetCore.Mvc;
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

		public IActionResult GetData()
		{
			var data = _dataAccessor.Read<Agent>();
			return Json(data);
		}
	}
}