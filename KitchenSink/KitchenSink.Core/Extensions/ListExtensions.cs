using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenSink.Core.Extensions
{
	public static class ListExtensions
	{
		public static void Add<TKey, TValue>(this IList<KvP<TKey, TValue>> addToMe, TKey key, TValue value)
		{
			addToMe.Add(new KvP<TKey, TValue>(key, value));
		}
	}
}
