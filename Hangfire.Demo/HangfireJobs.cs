using System;

namespace Hangfire.Demo
{
    public interface IHangfireJobs
    {
        void AddFireAndForget();
        void AddFailedJobRetry();
        void AddRecurringJob();
        void AddDelayedJob();
        void AddContinuations();
    }
    public class HangfireJobs : IHangfireJobs
    {
        private readonly IHangfireService hangfireService;

        public HangfireJobs(IHangfireService hangfireService)
        {
            this.hangfireService = hangfireService;
        }

        public void AddFireAndForget() => BackgroundJob.Enqueue(() => hangfireService.HelloFireAndForgetJob());

        public void AddFailedJobRetry() => BackgroundJob.Enqueue(() => hangfireService.HelloFailedJobRetry());

        public void AddRecurringJob() => RecurringJob.AddOrUpdate(() => hangfireService.HelloReccurringJob(), Cron.Minutely);

        public void AddDelayedJob() => BackgroundJob.Schedule(() => hangfireService.HelloDelayedJob(), TimeSpan.FromSeconds(10));

        public void AddContinuations()
        {
            string jobId = BackgroundJob.Enqueue(() => hangfireService.HelloContinuationFirstJob());
            BackgroundJob.ContinueJobWith(jobId, () => hangfireService.HelloContinuationSecondJob());
        }
    }
}
