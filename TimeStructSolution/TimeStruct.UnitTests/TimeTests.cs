using TimeStruct;

namespace TimeStruct.UnitTests
{
    [TestFixture]
    public class TimeTests
    {
        [TestCase(2, 30, 15, 9015)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 59, 59, 7199)]
        public void DurationInSecondsTest(int h, int m, int s, int expected)
        {
            var time = new Time(h, m, s);
            Assert.That(time.DurationInSeconds, Is.EqualTo(expected));
        }

        [TestCase(5, 75, 30, typeof(ArgumentException))]
        [TestCase(3, -1, 0, typeof(ArgumentException))]
        public void InvalidMinutes_ThrowsException(int h, int m, int s, Type exceptionType)
        {
            Assert.That(() => new Time(h, m, s), Throws.TypeOf(exceptionType));
        }

        [TestCase(12, 5, 30, "12:05:30")]
        [TestCase(1, 2, 3, "01:02:03")]
        [TestCase(0, 0, 0, "00:00:00")]
        public void ToStringTest(int h, int m, int s, string expected)
        {
            var time = new Time(h, m, s);
            Assert.That(time.ToString(), Is.EqualTo(expected));
        }

        [TestCase(1, 30, 0, 1, 30, 0, true)]
        [TestCase(2, 0, 0, 2, 0, 0, true)] 
        [TestCase(2, 0, 0, 1, 0, 0, false)]
        public void EqualsTest(int h1, int m1, int s1, int h2, int m2, int s2, bool expected)
        {
            var t1 = new Time(h1, m1, s1);
            var t2 = new Time(h2, m2, s2);
            Assert.That(t1.Equals(t2), Is.EqualTo(expected));
        }

        [Test]
        public void AdditionTest()
        {
            var t1 = new Time(1, 59, 59);
            var t2 = new Time(0, 0, 2);
            var result = t1 + t2;
            Assert.That(result.ToString(), Is.EqualTo("02:00:01"));
        }

        [Test]
        public void SubtractionTest()
        {
            var t1 = new Time(2, 0, 0);
            var t2 = new Time(1, 30, 0);
            var result = t1 - t2;
            Assert.That(result.ToString(), Is.EqualTo("00:30:00"));
        }

        [Test]
        public void MultiplyTest()
        {
            var t = new Time(1, 30, 0);
            var result = 1.5 * t;
            Assert.That(result.ToString(), Is.EqualTo("02:15:00"));
        }

        [Test]
        public void InvalidSubtraction_ThrowsException()
        {
            var t1 = new Time(1, 0, 0);
            var t2 = new Time(2, 0, 0);
            Assert.That(() => t1 - t2, Throws.InvalidOperationException);
        }
    }
}