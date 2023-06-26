namespace MauiApp2
{
    internal class WorkRecord
    {
        public int Id { get; internal set; }
        public DateTime Date { get; internal set; }
        public double WorkedHours { get; internal set; }
        public double HolidayAccrued { get; internal set; }
        public double Earnings { get; internal set; }
    }
}