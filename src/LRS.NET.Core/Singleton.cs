namespace LRS.NET.Core {
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;

	public class Singleton<T> {
		private static readonly IDictionary<Type, object> _instances;
		private static T _instance;

		static Singleton() {
			_instances = new ConcurrentDictionary<Type, object>();
		}

		public static IDictionary<Type, object> Instances {
			get { return _instances; }
		}

		public static T Instance {
			get { return _instance; }
			set {
				Instances[typeof (T)] = value;
				_instance = value;
			}
		}
	}
}