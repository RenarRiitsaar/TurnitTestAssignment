using TurnitBusStationApplication;

namespace TurnitBusStationApplicationTests {
    public class BreakTimeTests {

        [Fact]
        public void testBusiestTime() {
           
            List<BreakTime> breakTimes = new List<BreakTime>();

            breakTimes.Add(BreakTime.startAndEndTime("10:30-11:35"));
            breakTimes.Add(BreakTime.startAndEndTime("10:15-11:15"));
            breakTimes.Add(BreakTime.startAndEndTime("11:20-11:50"));
            breakTimes.Add(BreakTime.startAndEndTime("10:35-11:40"));
            breakTimes.Add(BreakTime.startAndEndTime("10:20-11:20"));

            var expected = "Busiest period is from 10:35 to 11:15 with 4 drivers on break.\r\n";

            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                BreakTime.busiestTime(breakTimes);
                var actual = sw.ToString();


                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void testStartAndEndTime() {

            BreakTime expectedBreakTime = new BreakTime(new DateTime(1, 1, 1, 10, 30, 0), new DateTime(1, 1, 1, 11, 30, 0));
           
            String time = "10:30-11:30";

            var actualBreakTime = BreakTime.startAndEndTime(time).ToString();

                Assert.Equal(expectedBreakTime.ToString(), actualBreakTime);
           
        }

        [Fact]
        public void testAddBreak() {

            List<BreakTime> breakTimes = new List<BreakTime>();


            String userInput = "13:00-13:45";
            var stringReader = new StringReader(userInput);
            Console.SetIn(stringReader);
            BreakTime.addBreak(breakTimes);

            Assert.Single(breakTimes);
            Assert.Equal(new TimeSpan(13, 0, 0), breakTimes[0].getStartTime().TimeOfDay);
            Assert.Equal(new TimeSpan(13, 45, 0), breakTimes[0].getEndTime().TimeOfDay);

        }
    }
}