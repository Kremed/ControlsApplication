using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlsApplication
{
    public partial class MainPage : ContentPage
    {
        //public DateTime currentDate { get; set; } = DateTime.Now;
        //public DateTime minimumDate { get; set; } = DateTime.Now;
        //public DateTime maximumDate { get; set; } = DateTime.Now.AddDays(10);
        public MainPage()
        {
            InitializeComponent();
            //BindingContext = this;
            MyDatePicker.MinimumDate = DateTime.Now; ;
            MyDatePicker.MaximumDate = DateTime.Now.AddDays(10);
            MyDatePicker.Date = DateTime.Now;

            //Time Stamp
            MyTimePicker.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); // Initial time (14:30 or 2:30 PM)

        }

        public void MyDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var SelectedDate = MyDatePicker.Date.ToString();
            LblSelectedDate.Text = "Selected Date : " + MyDatePicker.Date.ToString();
            LblDayName.Text = "Date Day Name : " + MyDatePicker.Date.DayOfWeek;
            LblDayOfYear.Text = "Date Day Of Year : " + MyDatePicker.Date.DayOfYear;
            LblDateFormat.Text = "Day Of Year : " + MyDatePicker.Date.ToString("MMM dd, yyyy hh:mm:ss.ffff tt zzz");
            LblShortDateFormat.Text = "Date To Short Date : " + MyDatePicker.Date.ToShortDateString();
            LblLongDateFormat.Text = "Date To Long Date : " + MyDatePicker.Date.ToLongDateString();
            LblTimeShortFormat.Text = "Date To Short Time : " + MyDatePicker.Date.ToShortTimeString();

            var test = MyDatePicker.Date - DateTime.Now;
        }

        private void MyTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var SelectedTime = MyTimePicker.Time.ToString();
            LblTimeShortFormat.Text = "Date To Short Time : " + MyTimePicker.Time;
            var date = Convert.ToDateTime("31/07/2024 18:17:00");
            date.AddDays(12);
        }

        private void BtnGoToAppointmentPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AppointmentPage());
        }
    }

}
