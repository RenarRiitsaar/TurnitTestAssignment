using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnitBusStationApplication {
    internal class UserOperations {


        public static void userOperations(List<BreakTime> breakTimes)
        {

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEnter the choice: \n 1. View break times" +
                    "\n 2. Add break time \n 3. Exit");

                String userInput = Console.ReadLine();
                int choice = Convert.ToInt32(userInput);

                switch (choice)
                {

                    case 1:
                        foreach(BreakTime breakTime in breakTimes)
                        {
                            Console.WriteLine(breakTime.ToString());
                        }
                        BreakTime.busiestTime(breakTimes);
                        break;

                    case 2:
                        BreakTime.addBreak(breakTimes);
                        BreakTime.busiestTime(breakTimes);
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}