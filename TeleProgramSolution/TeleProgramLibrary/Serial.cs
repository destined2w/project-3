using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary
{
    public class Serial : Show
    {
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public Serial(
            string title,
            string host,
            string description,
            ShowPeriodicity periodicity,
            string airTime,
            int season,
            int episode
        ) : base(title, host, description, periodicity, airTime)
        {
            SeasonNumber = season;
            EpisodeNumber = episode;
        }

        public override string[] GetInfo()
        {
            string[] baseInfo = base.GetInfo();
            string[] info = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Сезон: {SeasonNumber}, Эпизод: {EpisodeNumber}";
            return info;
        }
    }
}