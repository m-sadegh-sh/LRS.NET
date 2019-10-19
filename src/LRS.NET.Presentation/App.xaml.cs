namespace LRS.NET.Presentation {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.Composition;
	using System.ComponentModel.Composition.Hosting;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Runtime;
	using System.Waf.Applications;
	using System.Windows;
	using System.Windows.Threading;

	using LRS.NET.Controllers;
	using LRS.NET.Data;
	using LRS.NET.DataModels;
	using LRS.NET.Resources;
	using LRS.NET.Services;
	using LRS.NET.Settings;
	using LRS.NET.ViewModels;

	public partial class App : Application {
		private AggregateCatalog _catalog;
		private CompositionContainer _container;
		private IEnumerable<IModuleController> _moduleControllers;

		public App() {
			var profileRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), ApplicationInfo.ProductName, "ProfileOptimization");

			Directory.CreateDirectory(profileRoot);
			ProfileOptimization.SetProfileRoot(profileRoot);
			ProfileOptimization.StartProfile("Startup.profile");
		}

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			DispatcherUnhandledException += App_OnDispatcherUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += AppDomain_OnUnhandledException;

			_catalog = new AggregateCatalog();
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (ViewModel).Assembly));
			_catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (IEntityController).Assembly));
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (AppDbContext).Assembly));
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (DataModelBase<>).Assembly));
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (IEntityService).Assembly));
			_catalog.Catalogs.Add(new AssemblyCatalog(typeof (ViewModelBase<,>).Assembly));

			foreach (var assembly in AppSettings.Default.ModuleAssemblies)
				_catalog.Catalogs.Add(new AssemblyCatalog(assembly));

			_container = new CompositionContainer(_catalog, CompositionOptions.DisableSilentRejection);
			var batch = new CompositionBatch();
			batch.AddExportedValue(_container);
			_container.Compose(batch);

			_moduleControllers = _container.GetExportedValues<IModuleController>();

			foreach (var moduleController in _moduleControllers)
				moduleController.Initialize();

			foreach (var moduleController in _moduleControllers)
				moduleController.Run();
		}

		protected override void OnExit(ExitEventArgs e) {
			foreach (var moduleController in _moduleControllers.Reverse())
				moduleController.Shutdown();

			_container.Dispose();
			_catalog.Dispose();

			base.OnExit(e);
		}

		private static void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
			HandleException(e.Exception, false);
		}

		private static void AppDomain_OnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
			HandleException(e.ExceptionObject as Exception, e.IsTerminating);
		}

		private static void HandleException(Exception e, bool isTerminating) {
			if (e == null)
				return;

			Trace.TraceError(e.ToString());

			if (!isTerminating)
				MessageBox.Show(string.Format(CultureInfo.CurrentCulture, Messages.UnknownError, e), ApplicationInfo.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}