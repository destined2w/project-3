using System;
using NUnit.Framework;
using ShowLibrary;

namespace ShowLibrary.UnitTests
{
    [TestFixture]
    public class ShowUnitTests
    {
        [Test]
        public void ConstructorTest_PeriodicShow()
        {
            var show = CreatePeriodicShow();
            Assert.That(show.Title, Is.EqualTo("Новости дня"));
            Assert.That(show.Host, Is.EqualTo("Иван Петров"));
            Assert.That(show.Description, Is.EqualTo("Сводка новостей"));
            Assert.That(show.Frequency, Is.EqualTo(ShowFrequency.Daily));
            Assert.That(show.Time, Is.EqualTo(TimeSpan.Parse("20:00")));
            Assert.That(show.Date, Is.Null);
        }

        [Test]
        public void ConstructorTest_IrregularShow()
        {
            var show = CreateIrregularShow();
            Assert.That(show.Frequency, Is.EqualTo(ShowFrequency.Irregular));
            Assert.That(show.Date?.ToShortDateString(), Is.EqualTo("01.05.2024"));
        }

        [Test]
        public void GetInfoTest()
        {
            var show = CreatePeriodicShow();
            var info = show.GetInfo();
            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("«Новости дня» с участием Иван Петров"));
            Assert.That(info[1], Does.Contain("ежедневно").And.Contain("20:00"));
        }

        [Test]
        public void GetInfoTest_Irregular()
        {
            var show = CreateIrregularShow();
            var info = show.GetInfo();
            Assert.That(info[1], Does.Contain("непериодически").And.Contain("01.05.2024"));
        }

        private Show CreatePeriodicShow()
        {
            return new Show("Новости дня", "Иван Петров", "Сводка новостей", ShowFrequency.Daily, "20:00");
        }

        private Show CreateIrregularShow()
        {
            return new Show("Специальный выпуск", "Мария Иванова", "Экстренные новости", ShowFrequency.Irregular, "21:30", "01.05.2024");
        }
    }
}
