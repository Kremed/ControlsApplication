namespace ControlsApplication.Classes
{
    public class Appointment
    {
        public int ID = 0;
        public string clientName = "";
        public string clientPhone = "";
        public string clientEmail = "";
        public DateTime appointmentDate;
        public TimeSpan appointmentTime;              //Field


        public bool IsPhoneValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }
            else if (!phoneNumber.StartsWith("09") &&
                     !phoneNumber.StartsWith("00218") &&
                     !phoneNumber.StartsWith("+218"))
            {
                return false;
            }
            else if ((phoneNumber.StartsWith("09") && phoneNumber.Length != 10)
                   )
            {
                return false;
            }
            else if (phoneNumber.StartsWith("00218") && phoneNumber.Length != 10)
            {
                return false;
            }

            return true;
        }
    }
}
