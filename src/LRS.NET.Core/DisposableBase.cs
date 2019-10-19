namespace LRS.NET.Core {
	using System;

	public abstract class DisposableBase : IDisposable {
		private bool _disposed;

		public bool Disposed {
			get {
				lock (this) {
					return _disposed;
				}
			}
		}

		protected abstract void CoreDispose(bool disposeManagedResources);

		protected virtual void Dispose(bool disposeManagedResources) {
			lock (this) {
				if (_disposed)
					return;

				CoreDispose(disposeManagedResources);
				_disposed = true;

				GC.SuppressFinalize(this);
			}
		}

		public void Dispose() {
			Dispose(true);
		}

		~DisposableBase() {
			if (!Disposed)
				Dispose(false);
		}
	}
}