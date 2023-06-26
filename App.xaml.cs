
namespace MauiApp2
{
    public partial class App : Application
    {
        readonly List<WorkRecord> workRecords = new List<WorkRecord>();

        public App()
        {
            // Initialize the list of work records
            workRecords = new List<WorkRecord>();

            // Create a new work record instance
            WorkRecord record1 = new WorkRecord
            {
                Id = 1,
                Date = DateTime.Now,
                WorkedHours = 8.5,
                HolidayAccrued = 8.5 * 0.0107,
                Earnings = 8.5 * 15.0 // Assuming hourly rate is £15
            };

            // Add the work record to the list
            workRecords.Add(record1);

            // Retrieve and display the values from the work record
            WorkRecord retrievedRecord = workRecords[0];
            Console.WriteLine($"Date: {retrievedRecord.Date}");
            Console.WriteLine($"Worked Hours: {retrievedRecord.WorkedHours}");
            Console.WriteLine($"Holiday Accrued: {retrievedRecord.HolidayAccrued}");
            Console.WriteLine($"Earnings: {retrievedRecord.Earnings}");

            MainPage = new MainPage();
        }
    }
}