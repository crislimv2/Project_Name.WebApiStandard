namespace Project_Name.Commons.Extensions
{
    public class ConfigureSerilogOptions
    {
        public string? WriteErrorLogsToFile { set; get; }

        public bool WriteJsonToConsoleLog { set; get; }

        public bool WriteToSentry { set; get; }
    }
}