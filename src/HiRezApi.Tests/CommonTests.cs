namespace HiRezApi.Tests
{
    using System;
    using HiRezApi.Common;
    using NUnit.Framework;

    [TestFixture]
    public class CommonTests
    {
        [Test]
        public void TestToApiParameterHourAndMinTime()
        {
            var hourSpan = new TimeSpan(12, 0, 0);
            var minuteSpan = new TimeSpan(0, 10, 0);
            var hourSpanStr = hourSpan.ToApiParameterHourAndMinTime(minuteSpan);
            Assert.AreEqual(hourSpanStr, "12,10");
        }

        [Test]
        public void TestToApiParameterHourAndMinTimeHour()
        {
            var hourSpan = new TimeSpan(12, 0, 0);
            var hourSpanStr = hourSpan.ToApiParameterHourAndMinTime();
            Assert.AreEqual(hourSpanStr, "12");
        }

        [Test]
        public void TestToApiParameterHourTime()
        {
            var hourSpan = new TimeSpan(12, 0, 0);
            var hourSpanStr = hourSpan.ToApiParameterHourTime();
            Assert.AreEqual(hourSpanStr, "12");
        }

        [Test]
        public void ToApiParameterDate()
        {
            var dateTime = new DateTime(2017, 1, 15);
            var dateTimeStr = dateTime.ToApiParameterDate();
            Assert.AreEqual(dateTimeStr, "20170115");
        }
    }
}