using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary
{
    public class EducationalShow : Show
    {
        public string ScienceField { get; set; }

        public EducationalShow(
            string title,
            string host,
            string description,
            ShowPeriodicity periodicity,
            string airTime,
            string scienceField
        ) : base(title, host, description, periodicity, airTime)
        {
            ScienceField = scienceField;
        }

        public override string[] GetInfo()
        {
            string[] baseInfo = base.GetInfo();
            string[] info = new string[baseInfo.Length + 1];
            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Область науки: {ScienceField}";
            return info;
        }
    }
}