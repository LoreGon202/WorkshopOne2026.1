namespace Taller01
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public int Hour
        {
            get => _hour;
            private set
            {
                if (!ValidHour(value))
                    throw new ArgumentException($"The hour: {value}, is not valid.");
                _hour = value;
            }
        }

        public int Minute
        {
            get => _minute;
            private set
            {
                if (!ValidMinute(value))
                    throw new ArgumentException($"The minute: {value}, is not valid.");
                _minute = value;
            }
        }

        public int Second
        {
            get => _second;
            private set
            {
                if (!ValidSecond(value))
                    throw new ArgumentException($"The second: {value}, is not valid.");
                _second = value;
            }
        }

        public int Millisecond
        {
            get => _millisecond;
            private set
            {
                if (!ValidMillisecond(value))
                    throw new ArgumentException($"The millisecond: {value}, is not valid.");
                _millisecond = value;
            }
        }

        // Constructores sobrecargados
        public Time() : this(0, 0, 0, 0) { }
        public Time(int hour) : this(hour, 0, 0, 0) { }
        public Time(int hour, int minute) : this(hour, minute, 0, 0) { }
        public Time(int hour, int minute, int second) : this(hour, minute, second, 0) { }
        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }

        // Validaciones
        public bool ValidHour(int h) => h >= 0 && h <= 23;
        public bool ValidMinute(int m) => m >= 0 && m <= 59;
        public bool ValidSecond(int s) => s >= 0 && s <= 59;
        public bool ValidMillisecond(int ms) => ms >= 0 && ms <= 999;

        // Conversiones
        public long ToMilliseconds()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return ((long)Hour * 3600000) + ((long)Minute * 60000) + ((long)Second * 1000) + Millisecond;
        }

        public long ToSeconds()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return ((long)Hour * 3600) + ((long)Minute * 60) + Second;
        }

        public long ToMinutes()
        {
            if (!ValidHour(Hour) || !ValidMinute(Minute) || !ValidSecond(Second) || !ValidMillisecond(Millisecond))
                return 0;
            return ((long)Hour * 60) + Minute;
        }

        // Suma de tiempos
        public Time Add(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            int newHour = (int)((totalMs / 3600000) % 24);
            int newMinute = (int)((totalMs % 3600000) / 60000);
            int newSecond = (int)((totalMs % 60000) / 1000);
            int newMillisecond = (int)(totalMs % 1000);
            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        // Verifica si es otro día
        public bool IsOtherDay(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            return totalMs >= 24 * 3600000;
        }

        // Formato de salida
        public override string ToString()
        {
            string period = Hour >= 12 ? "PM" : "AM";
            int displayHour = Hour % 12;
            if (displayHour == 0) displayHour = 12;
            return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
        }
    }
}