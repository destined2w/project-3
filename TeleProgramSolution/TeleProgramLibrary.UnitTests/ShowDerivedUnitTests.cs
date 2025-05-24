using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleProgramLibrary.UnitTests
{
    [TestFixture]
    public class ShowDerivedUnitTests
    {
        [Test]
        public void EducationalShow_GetInfoTest()
        {
            var show = new EducationalShow(
                "Физика для всех",
                "Алексей Сидоров",
                "Основы механики",
                ShowPeriodicity.Weekly,
                "19:00",
                "Физика"
            );

            string[] info = show.GetInfo();
            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[2], Is.EqualTo("Область науки: Физика"));
        }

        [Test]
        public void Serial_GetInfoTest()
        {
            var show = new Serial(
                "Секретные материалы",
                "Дэвид Духовны",
                "Мистический триллер",
                ShowPeriodicity.Monthly,
                "21:30",
                5,
                12
            );

            string[] info = show.GetInfo();
            Assert.That(info[2], Is.EqualTo("Сезон: 5, Эпизод: 12"));
        }

        [Test]
        public void Movie_GetInfoTest()
        {
            var show = new Movie(
                "Интерстеллар",
                "Кристофер Нолан",
                "Фантастика о космосе",
                ShowPeriodicity.NonPeriodic,
                "25.12.2023 20:00",
                "Фантастика",
                "Кристофер Нолан",
                "США",
                2014
            );

            string[] info = show.GetInfo();
            Assert.That(info[2], Does.Contain("Жанр: Фантастика"));
            Assert.That(info[2], Does.Contain("Режиссер: Кристофер Нолан"));
        }
    }
}