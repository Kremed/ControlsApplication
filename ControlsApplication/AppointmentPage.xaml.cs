using ControlsApplication.Classes;

namespace ControlsApplication;

public partial class AppointmentPage : ContentPage
{
    public AppointmentPage()
    {
        InitializeComponent();
        MyDatePicker.MinimumDate = DateTime.Now.AddDays(1);
        MyDatePicker.MaximumDate = DateTime.Now.AddDays(10);
        MyDatePicker.Date = DateTime.Now;
        MyTimePicker.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); // Initial time (14:30 or 2:30 PM)
    }

    //public string clientName = "";
    //public string clientPhone = "";
    //public string clientEmail = "";
    //public DateTime appointmentDate;
    //public TimeSpan appointmentTime;
    Appointment appointment = new Appointment();
    List<Appointment> appointmentList = new List<Appointment>();



    private void BtnConfirm_Clicked(object sender, EventArgs e)
    {


        if (string.IsNullOrWhiteSpace(TxtName.Text))
        {
            DisplayAlert("تم رفض التسجيل", "الرجاء ادخال اسم صاحب الحجز, اسم صاحب الحجز مطلوب", "موافق");
            return;
        }

        if (string.IsNullOrWhiteSpace(TxtEmail.Text) ||
            !TxtEmail.Text.Contains("@"))
        {
            DisplayAlert("تم رفض التسجيل", "الرجاء ادخال البريد الألكتروني بشكل صحيح, االبريد الألكتروني مطلوب", "موافق");
            return;
        }
        //      "0924474464";
        //if (string.IsNullOrWhiteSpace(TxtPhone.Text) ||
        //    (!TxtPhone.Text.StartsWith("09") &&
        //    !TxtPhone.Text.StartsWith("00218") &&
        //    !TxtPhone.Text.StartsWith("+218"))
        //    )
        //{
        //    DisplayAlert("تم رفض التسجيل", "الرجاء التــأكد من رقم الهاتف, يجب ان يكون رقم الهاتف بالصيغة الصحيحة", "موافق");
        //    return;
        //}

        var isPhoneValid = appointment.IsPhoneValid(TxtPhone.Text);
        if (!isPhoneValid)
        {
            DisplayAlert("تم رفض التسجيل", "الرجاء التــأكد من موعد تاريخ الحجز, يجب ان يكون بعد تاريخ اليوم", "موافق");
            return;
        }

        if (appointment.appointmentDate < DateTime.Now.AddDays(1))
        {
            DisplayAlert("تم رفض التسجيل", "الرجاء التــأكد من موعد تاريخ الحجز, يجب ان يكون بعد تاريخ اليوم", "موافق");
            return;
        }

        //appointment.ID = appointmentList.Count() + 1;
        appointment.clientName = TxtName.Text;
        appointment.clientEmail = TxtEmail.Text;
        appointment.clientPhone = TxtPhone.Text;
       
        appointmentList.Add(appointment);

        appointment = new();

        DisplayAlert(
            "تم حجز الموعد",
            "تم حجز الموعد بنجاح بيانات الموعد هي:" + Environment.NewLine +
            "الاسم: " + appointment.clientName + Environment.NewLine +
            "البريد الالكتروني: " + appointment.clientEmail + Environment.NewLine +
            "رقم الهاتف: " + appointment.clientPhone + Environment.NewLine +
            "تــاريخ الحجز: " + appointment.appointmentDate.ToShortDateString() + Environment.NewLine +
            "توقيت الحجز: " + appointment.appointmentTime,
            "شكرا");

    }

    private void MyTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        appointment.appointmentTime = MyTimePicker.Time;
    }

    private void MyDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        appointment.appointmentDate = MyDatePicker.Date;
    }


}

