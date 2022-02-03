using System;
using System.Threading.Tasks;

namespace Hangfire.Demo
{
    public interface IHangfireService
    {
        Task HelloFireAndForgetJob();
        Task HelloFailedJobRetry();
        Task HelloReccurringJob();
        Task HelloDelayedJob();
        Task HelloContinuationFirstJob();
        Task HelloContinuationSecondJob();
    }

    public class HangfireService : IHangfireService
    {
        public async Task HelloFireAndForgetJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello Hangfire Fire And Forget Job!");
            });
        }

        public async Task HelloFailedJobRetry()
        {
            await Task.Run(() =>
            {
                throw new Exception("Hangfire Failed Job Retry...");
            });
        }

        public async Task HelloReccurringJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello Hangfire Recurring Job!");
            });
        }

        public async Task HelloDelayedJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello Hangfire Delayed Job!!");
            });
        }

        public async Task HelloContinuationFirstJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello Hangfire Continuation First Job!");
            });
        }

        public async Task HelloContinuationSecondJob()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Hello Hangfire Continuation Second Job");
            });
        }
    }
}
