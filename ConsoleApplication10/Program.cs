using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 4;                                         //4 id count for 4 instructor
            DateTime today = DateTime.Today.AddHours(7);        //Get today date and set it to 7am
            DateTime start = today.AddDays(45);                 //Get the date that is 45 days from today as start of the period
            DateTime end = start.AddDays(30);                   //Get the date that is 30 days from the start date
            //DateTime start = today;                 //Get the date that is 45 days from today as start of the period
            //DateTime end = start.AddDays(30);                   //Get the date that is 30 days from the start date
            SQL query = new SQL();
            StreamWriter write = new StreamWriter(@"D:\Uni 2017\Comp219\SQL Insert.txt");

            while (start.Date <= end.Date)                      //while there still more day
            {

                if (start.DayOfWeek.ToString() != "Sunday")     //check if that day is not a Sunday
                {
                    while (start.Hour < 20)                     //create timeslot from 7:00 to 21:00
                    {
                        if (start.DayOfWeek.ToString() == "Saturday")   //if day is a Saturday then create only one slot for each hour
                        {
                            int i = 1;
                            //write.WriteLine("INSERT into timeslot values (" + i + ",'" + start.TimeOfDay + "','" + start.ToString("MM/dd/yyyy") + "')");
                            SQL.executeQuery("INSERT into timeslot values (" + i + ",'" + start.TimeOfDay + "','" + start.ToString("MM/dd/yyyy") + "')");
                        }
                        else
                        {
                            for (int i = 1; i <= id; i++)
                            {
                                // write.WriteLine("INSERT into timeslot values (" + i + ",'" + start.TimeOfDay + "','" + start.ToString("MM/dd/yyyy") + "')");
                                SQL.executeQuery("INSERT into timeslot values (" + i + ",'" + start.TimeOfDay + "','" + start.ToString("MM/dd/yyyy") + "')");
                            }
                        }
                        start = start.AddHours(1);
                    }
                    start = start.AddHours(12);
                }
                else            //no slot created on Sundays
                {
                    start = start.AddDays(1);
                }
                
            }
            write.Close();
            Console.WriteLine("finished");
            //Console.WriteLine (start.DayOfWeek);
            Console.Read();
        }
    }
}
