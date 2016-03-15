using System;
using System.Linq;


namespace XigniteMessageQueue
{
	public static class Utils
	{
		public static string ToStringNullSafe(this object obj)
		{
			return obj != null ? obj.ToString() : String.Empty;
		}
		public static bool Compare<T>(T source, T target, params string[] ignore)
		{
			int count = source.GetType().GetProperties().Count();
			
			for (int i = 0; i < count; i++)
			{
				var sourceProperty = source.GetType().GetProperties()[i].GetValue(source, null).ToStringNullSafe();
				var targetProperty = target.GetType().GetProperties()[i].GetValue(target, null).ToStringNullSafe();
				if (sourceProperty != targetProperty && ignore.All(x => x != sourceProperty.GetType().GetProperties()[i].Name))
				{
					return false;
				}
			}
			return true;
		}
	}
}
