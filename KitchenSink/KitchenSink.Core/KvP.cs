using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core
{
	public class KvP<TKey, TValue>
	{
		public KvP(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
		public TKey Key { get; }
		public TValue Value { get; set; }
	}
}
