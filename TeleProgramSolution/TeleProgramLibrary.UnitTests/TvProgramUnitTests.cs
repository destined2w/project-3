using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary.UnitTests
{
    [TestFixture]
    public class TvProgramUnitTests
    {
        [Test]
        public void Constructor_FiltersShowsByDate()
        {
            var date = new DateTime(2023, 12, 25);
            var show1 = new Show("Фильм", "Режиссер", "...", ShowPeriodicity.NonPeriodic, "25.12.2023 20:00");
            var show2 = new Show("Сериал", "Ведущий", "...", ShowPeriodicity.Daily, "26.12.2023 21:00");

            var program = new TvProgram(date, new[] { show1, show2 });

            Assert.That(program.Count, Is.EqualTo(1));
            Assert.That(program.Date, Is.EqualTo(date));
        }

        [Test]
        public void ShowsAreSortedByAirTime()
        {
            var date = new DateTime(2023, 12, 25);
            var show1 = new Show("Фильм", "Режиссер", "...", ShowPeriodicity.NonPeriodic, "25.12.2023 20:00");
            var show2 = new Show("Сериал", "Ведущий", "...", ShowPeriodicity.NonPeriodic, "25.12.2023 19:00");

            var program = new TvProgram(date, new[] { show1, show2 });

            var shows = new List<Show>(program);
            Assert.That(shows[0].AirTime, Is.EqualTo(show2.AirTime));
            Assert.That(shows[1].AirTime, Is.EqualTo(show1.AirTime));
        }

        [Test]
        public void IEnumerable_IteratesAllShows()
        {
            var date = new DateTime(2023, 12, 25);
            var show1 = new Show("Фильм", "Режиссер", "...", ShowPeriodicity.NonPeriodic, "25.12.2023 20:00");
            var program = new TvProgram(date, new[] { show1 });

            int count = 0;
            foreach (var show in program)
            {
                count++;
                Assert.That(show, Is.SameAs(show1));
            }
            Assert.That(count, Is.EqualTo(1));
        }
    }
}