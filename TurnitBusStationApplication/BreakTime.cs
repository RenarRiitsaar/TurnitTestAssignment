using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnitBusStationApplication{

    public class BreakTime {
        private DateTime startTime { get; }
        private DateTime endTime { get; }

        public BreakTime(DateTime startTime, DateTime endTime){

            this.startTime = startTime;
            this.endTime = endTime;
        }

        public static BreakTime startAndEndTime(String time) {
            String[] times = time.Split("-");
            DateTime startTime = DateTime.Parse(times[0]);
            DateTime endTime = DateTime.Parse(times[1]);

            if (startTime > endTime) {
                return null;

            }else{
                return new BreakTime(startTime, endTime);
            }
        }

        public static void busiestTime(List<BreakTime> breakTimes){
            var breaks = new List<Tuple<DateTime, int>>();

            foreach (var breakTime in breakTimes){
                breaks.Add(new Tuple<DateTime, int>(breakTime.startTime, 1)); // Start of break
                breaks.Add(new Tuple<DateTime, int>(breakTime.endTime.AddMinutes(-1), -1)); // End of break
            }

            breaks.Sort((s, e) => s.Item1.CompareTo(e.Item1));

            int maxDriversOnBreak = 0;
            int driversCurrentlyOnBreak = 0;

            DateTime currentStartTime = DateTime.MinValue;
            DateTime busiestStartTime = DateTime.MinValue;
            DateTime busiestEndTime = DateTime.MinValue;

            foreach (var brk in breaks){

                if (driversCurrentlyOnBreak > maxDriversOnBreak){

                    maxDriversOnBreak = driversCurrentlyOnBreak;
                    busiestStartTime = currentStartTime;
                    busiestEndTime = brk.Item1.AddMinutes(1);
                }

                driversCurrentlyOnBreak += brk.Item2;

                if (driversCurrentlyOnBreak == maxDriversOnBreak){
                    busiestEndTime = brk.Item1;
                }

                if (brk.Item2 == 1) {
                    currentStartTime = brk.Item1;
                }
            }

            Console.WriteLine($"Busiest period is from {busiestStartTime:HH:mm} to {busiestEndTime:HH:mm} with {maxDriversOnBreak} drivers on break.");
        }

        public static void addBreak(List<BreakTime> breakTimes) {
            Console.WriteLine("Please enter the break time. (Format example: 13:00-13:45)");
            var addBreak = Console.ReadLine();
            try {
                   BreakTime brk = BreakTime.startAndEndTime(addBreak);

                if (addBreak != null && brk != null) {
                    breakTimes.Add(brk);
                }else{

                    Console.WriteLine("Something went wrong with add. Try again!");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("\n Wrong time format, try again!");
            }
        }

        public override string ToString(){
            return $"Start: {startTime:HH:mm}, End: {endTime:HH:mm}";
        }

        public DateTime getStartTime() {
            return this.startTime;
        }
        public DateTime getEndTime() {
            return this.endTime;
        }
    }
}
