namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private double workedHours;
        private List<Shifts> savedShifts;
        private IView shiftLabels;

       

        public MainPage()
        {
            InitializeComponent();
            savedShifts = new List<Shifts>();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
             //this class is used for the Calculate button in my code
            // Get the entered worked hours for each day of the week
            double mondayHours = GetEnteredHours(MondayHoursEntry);
            double tuesdayHours = GetEnteredHours(TuesdayHoursEntry);
            double wednesdayHours = GetEnteredHours(WednesdayHoursEntry);
            double thursdayHours = GetEnteredHours(ThursdayHoursEntry);
            double fridayHours = GetEnteredHours(FridayHoursEntry);
            double saturdayHours = GetEnteredHours(SaturdayHoursEntry);
            double sundayHours = GetEnteredHours(SundayHoursEntry);

            // Calculate the total worked hours for the week
            double totalHours = mondayHours + tuesdayHours + wednesdayHours + thursdayHours + fridayHours + saturdayHours + sundayHours;

            // Calculate the holiday accrued
            double holidayAccrued;
            if (totalHours < 8)
            {
                holidayAccrued = totalHours * 0.107;
            }
            else
            {
                int workedDays;
                if (totalHours > 40)
                {
                    workedDays = 5; // Assuming 5 working days in a week
                }
                else
                {
                    workedDays = (int)Math.Floor(totalHours / 8);
                }
                holidayAccrued = workedDays * 0.107;
            }
;
//from line 18 to line 49, the code has been created using ChatGPT because I wasn't sure about how to create a button in the code.
//The code is the Calculate button in the application and once pressed, the application calculates the wages and the holiday
//The calculations were made by me, based on 28 days holiday/year, this means 0.107/day assuming the work day has 8 hours, if is the shift is longer than 8 hours, the holiday will still be based on 8 hours
//if is less than 8 hours, it will be calculated based on the number of hours worked.

            // Calculate the earnings based on the hourly rate
            double hourlyRate = 15.0; //The hourly rate in this case is £15 for  weekdays
            double weekendHourlyRate = 20.0; //The hourly rate is £20 for weekends
            double earnings = (mondayHours + tuesdayHours + wednesdayHours + thursdayHours + fridayHours) * hourlyRate
                + (saturdayHours + sundayHours) * weekendHourlyRate;

           
            HolidayAccruedLabel.Text = $"Holiday Accrued: {holidayAccrued} days";
            EarningsLabel.Text = $"Earnings: £{earnings}";
        }
        private double GetEnteredHours(Entry entry)
        {
            if (double.TryParse(entry.Text, out double hours)) 
            {
                return hours;
            }
            return 0;
        }
        {
         
        private void RecordShiftButton_Clicked(object sender, EventArgs e)
        {
            // Get the entered worked hours for each day of the week
            double mondayHours = GetEnteredHours(MondayHoursEntry);
            double tuesdayHours = GetEnteredHours(TuesdayHoursEntry);
            double wednesdayHours = GetEnteredHours(WednesdayHoursEntry);
            double thursdayHours = GetEnteredHours(ThursdayHoursEntry);
            double fridayHours = GetEnteredHours(FridayHoursEntry);
            double saturdayHours = GetEnteredHours(SaturdayHoursEntry);
            double sundayHours = GetEnteredHours(SundayHoursEntry);

            // Create a Shifts object with the entered hours
            Shifts shifts = new Shifts
            {
                MondayHours = mondayHours,
                TuesdayHours = tuesdayHours,
                WednesdayHours = wednesdayHours,
                ThursdayHours = thursdayHours,
                FridayHours = fridayHours,
                SaturdayHours = saturdayHours,
                SundayHours = sundayHours
            };

            // Add the shifts to the savedShifts list, however I am not able to access the saved shift lists in my code
            savedShifts.Add(shifts);

            //This is what the user sees when they save their shifs
            DisplayAlert("Shifts Saved", "Your shifts have been saved successfully.", "OK", "Exit");
            //ChatGPT has been used to create this button
        }
     //Some of the errors in the code have been fixed 
     //




    }
}
