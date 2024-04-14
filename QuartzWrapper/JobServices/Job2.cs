using Quartz;
using Quartz.Abstraction.Attribute;
using Quartz.Abstraction.Interfaces;

namespace QuartzWrapper.JobServices
{
    [JobScheduler("Test2", "0/5 * * ? * * *")]
    public class Job2 : IJobBase
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Every 5 Second");

            return Task.CompletedTask;
        }
    }
}
