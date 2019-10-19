namespace LRS.NET.Core.Jobs {
	using Quartz;

	public interface IJobScheduler {
		void Schedule(IScheduler scheduler);
	}
}