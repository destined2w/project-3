using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowLibrary
{
    public class Show
    {
        public string Title { get; set; }
        public string Host { get; set; }
        public string Description { get; set; }
        public readonly ShowFrequency Frequency;
        public readonly TimeSpan Time;
        public readonly DateTime? Date;

        public Show(string title, string host, string description, ShowFrequency frequency, string time, string? date = null)
        {
            Title = title;
            Host = host;
            Description = description;
            Frequency = frequency;

            if (!TimeSpan.TryParse(time, out Time))
                throw new ArgumentException("Неверный формат времени.");

            if (frequency == ShowFrequency.Irregular)
            {
                if (string.IsNullOrEmpty(date) || !DateTime.TryParse(date, out var parsedDate))
                    throw new ArgumentException("Для непериодической передачи необходимо указать корректную дату");
                Date = parsedDate;
            }
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"«{Title}» с участием {Host}";
            string frequency = Frequency switch
            {
                ShowFrequency.Daily => "ежедневно",
                ShowFrequency.Weekly => "еженедельно",
                ShowFrequency.Monthly => "ежемесячно",
                _ => "непериодически"
            };
            info[1] = $"Описание: {Description}. Периодичность: {frequency}. Время выхода: {Time:hh\\:mm}";

            if (Frequency == ShowFrequency.Irregular && Date.HasValue)
            {
                info[1] += $". Дата выхода: {Date.Value:d}.";
            }

            return info;
        }
    }
}