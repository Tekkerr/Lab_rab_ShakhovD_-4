using System;

namespace Lab_rab_ShakhovD_Вариант4
{
    public class TimeData
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public int GetFullMinutes()
        {
            return Hours * 60 + Minutes;
        }

        public void MinusTenMinutes()
        {
            DateTime dt = new DateTime(2000, 1, 1, Hours, Minutes, Seconds);
            dt = dt.AddMinutes(-10);

            Hours = dt.Hour;
            Minutes = dt.Minute;
            Seconds = dt.Second;
        }
    }
}
