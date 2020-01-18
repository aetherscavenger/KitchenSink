using KitchenSink.Core.DataAccessor;
using System.Collections.Generic;

namespace KitchenSinkApi.PersistenceEmulator.Aggregators
{
	public interface IAggregator<T>
	{
		#region Public Methods

		List<T> Get(int id);

		List<T> GetAll();

		void Remove(int id);

		IEntity Set(T setMe);

		#endregion Public Methods
	}
}