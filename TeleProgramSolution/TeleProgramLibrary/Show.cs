using System;

namespace TeleProgramLibrary
{
    public class Show
    {
        public string Title { get; set; }
        public string Host { get; set; }
        public string Description { get; set; }
        public readonly ShowPeriodicity Periodicity;
        public readonly DateTime AirTime;

        public Show(
            string title,
            string host,
            string description,
            ShowPeriodicity periodicity,
            string airTime
        )
        {
            Title = title;
            Host = host;
            Description = description;
            Periodicity = periodicity;

            if (periodicity == ShowPeriodicity.NonPeriodic)
            {
                if (!DateTime.TryParse(airTime, out AirTime))
                    throw new ArgumentException("Неверный формат даты и времени");
            }
            else
            {
                if (!DateTime.TryParseExact(
                    airTime,
                    "HH:mm",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out AirTime
                ))
                    throw new ArgumentException("Неверный формат времени");
            }
        }

        public virtual string[] GetInfo()
        {
            string[] info = new string[2];
            info[0] = $"{Title} | Ведущий: {Host}";

            string periodicityStr;
            switch (Periodicity)
            {
                case ShowPeriodicity.Daily:
                    periodicityStr = "Ежедневная";
                    break;
                case ShowPeriodicity.Weekly:
                    periodicityStr = "Еженедельная";
                    break;
                case ShowPeriodicity.Monthly:
                    periodicityStr = "Ежемесячная";
                    break;
                default:
                    periodicityStr = "Непериодическая";
                    break;
            }

            string airTimeStr = (Periodicity == ShowPeriodicity.NonPeriodic)
                ? AirTime.ToString("dd.MM.yyyy HH:mm")
                : AirTime.ToString("HH:mm");

            info[1] = $"Периодичность: {periodicityStr}. Время выхода: {airTimeStr}.\nОписание: {Description}";
            return info;
        }
    }
}
