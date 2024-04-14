How to Use : 

STEP 1:
program.cs File Should Config This Wrapper :

builder.Services.JobRunnerConfiguration(Assembly.GetExecutingAssembly());

Step 2:
That Service You Want to Be Scheduled By Quartz : 


[JobScheduler("ThisIsJobName ", "* * * * * ? *")]

public class Gretting : IJobBase
{
    public Task Excute(IJobExecutionContext context)
    {
       ///Here Will Be What You Want To Be a Job -- Your Service
       Console.WriteLine("Hello World");

       return Task.CompletedTask;
    }
}


