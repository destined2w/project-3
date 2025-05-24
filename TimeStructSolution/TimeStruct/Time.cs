using System;

namespace TimeStruct
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private int _hours;
        private int _minutes;
        private int _seconds;

        public int H
        {
            get => _hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Часы не могут быть отрицательными");
                _hours = value;
            }
        }

        public int M
        {
            get => _minutes;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Минуты должны быть от 0 до 59");
                _minutes = value;
            }
        }

        public int S
        {
            get => _seconds;
            set
            {
                if (value < 0 || value > 59)
                    throw new ArgumentException("Секунды должны быть от 0 до 59");
                _seconds = value;
            }
        }

        public int DurationInSeconds => H * 3600 + M * 60 + S;

        public Time(int hours, int minutes, int seconds) : this()
        {
            H = hours;
            M = minutes;
            S = seconds;
        }

        public override string ToString() => $"{H:D2}:{M:D2}:{S:D2}";

        public bool Equals(Time other) => DurationInSeconds == other.DurationInSeconds;
        public override bool Equals(object obj) => obj is Time other && Equals(other);
        public override int GetHashCode() => DurationInSeconds.GetHashCode();

        public int CompareTo(Time other) => DurationInSeconds.CompareTo(other.DurationInSeconds);

        public static bool operator ==(Time a, Time b) => a.Equals(b);
        public static bool operator !=(Time a, Time b) => !a.Equals(b);
        public static bool operator >(Time a, Time b) => a.CompareTo(b) > 0;
        public static bool operator <(Time a, Time b) => a.CompareTo(b) < 0;
        public static bool operator >=(Time a, Time b) => a.CompareTo(b) >= 0;
        public static bool operator <=(Time a, Time b) => a.CompareTo(b) <= 0;

        public static Time operator +(Time a, Time b)
        {
            int total = a.DurationInSeconds + b.DurationInSeconds;
            return FromSeconds(total);
        }

        public static Time operator -(Time a, Time b)
        {
            if (a < b) throw new InvalidOperationException("Вычитаемое больше уменьшаемого");
            int total = a.DurationInSeconds - b.DurationInSeconds;
            return FromSeconds(total);
        }

        public static Time operator *(double k, Time t)
        {
            if (k < 0) throw new ArgumentException("Коэффициент должен быть неотрицательным");
            int seconds = (int)Math.Round(t.DurationInSeconds * k);
            return FromSeconds(seconds);
        }

        public static Time operator *(Time t, double k) => k * t;

        private static Time FromSeconds(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int remaining = totalSeconds % 3600;
            int minutes = remaining / 60;
            int seconds = remaining % 60;
            return new Time(hours, minutes, seconds);
        }
    }
}