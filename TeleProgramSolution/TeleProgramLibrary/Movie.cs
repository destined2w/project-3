using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary
{
    public class Movie : Show
    {
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public int ReleaseYear { get; set; }

        public Movie(
            string title,
            string host,
            string description,
            ShowPeriodicity periodicity,
            string airTime,
            string genre,
            string director,
            string country,
            int releaseYear
        ) : base(title, host, description, periodicity, airTime)
        {
            Genre = genre;
            Director = director;
            Country = country;
            ReleaseYear = releaseYear;
        }

        public override string[] GetInfo()
        {
            string[] baseInfo = base.GetInfo();
            string[] info = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Жанр: {Genre}, Режиссер: {Director}, Страна: {Country}, Год: {ReleaseYear}";
            return info;
        }
    }
}