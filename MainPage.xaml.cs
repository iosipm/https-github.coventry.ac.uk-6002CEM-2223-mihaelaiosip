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
//from line 18 to line 49, te code has been created with ChatGpt, however, I have done the calculations, for example on lane 49, also, I have created all the variables. I needed help with syntax in this matter
//so the rest of the code was easier to create

            // Calculate the earnings based on the hourly rate
            double hourlyRate = 15.0; // Assuming hourly rate is £15 for weekdays
            double weekendHourlyRate = 20.0; // Assuming hourly rate is £20 for weekends
            double earnings = (mondayHours + tuesdayHours + wednesdayHours + thursdayHours + fridayHours) * hourlyRate
                + (saturdayHours + sundayHours) * weekendHourlyRate;

            // Update the labels with the calculated values
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

        private void OnSaveShiftsClicked(object sender, EventArgs e)
        {
            Shifts shifts = new Shifts
            {
                MondayHours = GetEnteredHours(MondayHoursEntry),
                TuesdayHours = GetEnteredHours(TuesdayHoursEntry),
                WednesdayHours = GetEnteredHours(WednesdayHoursEntry),
                ThursdayHours = GetEnteredHours(ThursdayHoursEntry),
                FridayHours = GetEnteredHours(FridayHoursEntry),
                SaturdayHours = GetEnteredHours(SaturdayHoursEntry),
                SundayHours = GetEnteredHours(SundayHoursEntry)
            };

            savedShifts.Add(shifts);

            DisplayAlert("Shifts Saved", "Your shifts have been saved successfully.", "OK");
        }
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

            // Add the shifts to the savedShifts list
            savedShifts.Add(shifts);

            // Display a confirmation message
            DisplayAlert("Shifts Saved", "Your shifts have been saved successfully.", "OK");
        }
     




    }
}
