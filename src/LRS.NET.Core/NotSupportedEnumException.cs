namespace LRS.NET.Core {
	using System;

	[Serializable]
	public sealed class NotSupportedEnumException : Exception {
		public NotSupportedEnumException(object value) : base(string.Format("{0}.{1} enum is not supported.", value.GetType().Name, value)) {}

		public NotSupportedEnumException(string message) : base(message) {}

		public NotSupportedEnumException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args)) {}

		public NotSupportedEnumException(string message, Exception innerException) : base(message, innerException) {}
	}
}