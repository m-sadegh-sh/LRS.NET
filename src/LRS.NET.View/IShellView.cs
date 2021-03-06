﻿namespace LRS.NET.View {
	using System;
	using System.ComponentModel;
	using System.Waf.Applications;

	public interface IShellView : IView {
		double Left { get; set; }
		double Top { get; set; }
		double Width { get; set; }
		double Height { get; set; }
		bool IsMaximized { get; set; }

		event CancelEventHandler Closing;
		event EventHandler Closed;

		void Show();
		void Close();
	}
}