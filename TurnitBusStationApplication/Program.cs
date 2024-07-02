namespace TurnitBusStationApplication{
    internal class Program{
        static void Main(string[] args){
            List<BreakTime> breakTimes = new List<BreakTime>();

            PathVerification.pathVerification(args, breakTimes);
            UserOperations.userOperations(breakTimes);
           
       
            }
        }
    }


