using NUnit.Framework;
using System;
using TeleProgramLibrary;
using TeleProgramLibrary.UnitTests;

namespace TeleProgramLibrary.UnitTests
{
    [TestFixture]
    public class ShowUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var show = CreateTestShow();
            Assert.That(show.Title, Is.EqualTo("Утренние новости"));
            Assert.That(show.Host, Is.EqualTo("Иван Иванов"));
            Assert.That(show.Periodicity, Is.EqualTo(ShowPeriodicity.Daily));
            Assert.That(show.AirTime.ToString("HH:mm"), Is.EqualTo("08:00"));
        }

        [Test]
        public void NonPeriodicShowTest()
        {
            var show = new Show(
                "Финал шоу",
                "Анна Петрова",
                "Финал сезона",
                ShowPeriodicity.NonPeriodic,
                "25.12.2023 20:00"
            );
            Assert.That(show.AirTime.ToString("dd.MM.yyyy"), Is.EqualTo("25.12.2023"));
        }

        [Test]
        public void GetInfoTest()
        {
            var show = CreateTestShow();
            string[] info = show.GetInfo();
            Assert.That(info[0], Is.EqualTo("Утренние новости | Ведущий: Иван Иванов"));
            Assert.That(info[1], Does.StartWith("Периодичность: Ежедневная. Время выхода: 08:00."));
        }

        private Show CreateTestShow()
        {
            return new Show(
                "Утренние новости",
                "Иван Иванов",
                "Новостная программа",
                ShowPeriodicity.Daily,
                "08:00"
            );
        }
    }
}
