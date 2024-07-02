using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnitBusStationApplication {
    internal class PathVerification {
        public PathVerification() { }

        public static void pathVerification(String[] args, List<BreakTime> breakTimes)
        {

            try
            {
                if (args[0] == "filename")
                {


                    String filePath = args[1];
                    if (File.Exists(filePath))
                    {

                        Console.WriteLine("File found! \n");
                        Console.WriteLine("Break times from file: \n");
                        Thread.Sleep(2000);

                       getBreakTimesFromFile(filePath, breakTimes);
                        BreakTime.busiestTime(breakTimes);

                    }
                    else
                    {

                        Console.WriteLine("File not found. Check the file path!");
                        System.Environment.Exit(5);
                    }
                }
                else if (args[0] != "filename")
                {

                    Console.WriteLine("Use 'filename path/to/file/file.txt' command");
                    System.Environment.Exit(5);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e}");
                Console.WriteLine("Insert filename path/to/file.txt");
                System.Environment.Exit(5);
            }


        }
        public static void getBreakTimesFromFile(String filePath, List<BreakTime> breakTimes){

            String[] fileEntries = File.ReadAllLines(filePath);
            foreach (String entry in fileEntries){

                breakTimes.Add(BreakTime.startAndEndTime(entry));
                Console.Write(entry.ToString() + "\n");
            }
        }
    }
}
        