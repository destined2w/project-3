using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary
{
    public class TvProgram : IEnumerable<Show>
    {
        public DateTime Date { get; }
        public int Count => _shows.Count;
        private readonly List<Show> _shows = new List<Show>();

        public TvProgram(DateTime date, IEnumerable<Show> shows)
        {
            Date = date;
            foreach (var show in shows)
            {
                if (show.AirTime.Date == date.Date && !_shows.Contains(show))
                {
                    _shows.Add(show);
                }
            }
            _shows.Sort(); // Сортировка по AirTime
        }

        public IEnumerator<Show> GetEnumerator() => _shows.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
