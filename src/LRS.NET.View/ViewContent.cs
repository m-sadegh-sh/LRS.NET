namespace LRS.NET.View {
	using System.Waf.Applications;

	public class ViewContent {
		private readonly string _title;
		public IView ListView { get; private set; }
		public IView View { get; private set; }

		public ViewContent(string title, IView listView, IView view) {
			_title = title;
			ListView = listView;
			View = view;
		}

		public override string ToString() {
			return _title;
		}
	}
}