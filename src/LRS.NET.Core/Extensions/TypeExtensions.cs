namespace LRS.NET.Core.Extensions {
	using System;

	using CuttingEdge.Conditions;

	public static class TypeExtensions {
		public static bool IsNullable(this Type type) {
			Condition.Requires(type).IsNotNull();

			if (!type.IsValueType)
				return true;

			if (Nullable.GetUnderlyingType(type) != null)
				return true;

			return false;
		}
	}
}