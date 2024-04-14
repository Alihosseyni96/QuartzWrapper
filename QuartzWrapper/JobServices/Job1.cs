using Quartz;
using Quartz.Abstraction.Attribute;
using Quartz.Abstraction.Interfaces;

namespace QuartzWrapper.JobServices
{
    [JobScheduler("Test1", "* * * * * ? *")]
    public class Job1 : IJobBase
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Every 1 Second");


            return Task.CompletedTask;
        }
    }
}
