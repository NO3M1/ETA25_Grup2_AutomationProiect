using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject.Tests
{
    public class ListsArrays
    {
        [Test]
        public void TestList_Arrays()
        {
            Dictionary<string, string> obiecte = new Dictionary<string, string>
            {
                {"obiect","mouse"},
                {"fruct", "portocala"},
                {"sport", "fotbal"}
            };

            foreach (var obiect in obiecte)
            {
                Console.WriteLine($"Key is: {obiect.Key}");
                Console.WriteLine($"Value is: {obiect.Value}");
            }

            Dictionary<string, List<string>> classifications = new Dictionary<string, List<string>>();
            List<string> citiesOfRomania = new List<string> { "Bucuresti", "Timisoara", "Iasi" };
            List<string> citiesOfFrance = new List<string> { "Paris", "Lyon", "" };
            List<string> citiesOfItaly = new List<string> { "Roma", "Napoli", "Milano" };

            classifications.Add("Romania", citiesOfRomania);
            //classifications["Romania"] = citiesOfRomania;
            classifications["France"] = citiesOfFrance;
            classifications["Italy"] = citiesOfItaly;

            foreach (var key in classifications.Keys)
            {
                Console.WriteLine($"Country is: {key}");
                Console.WriteLine($"Cities are: " + string.Join(",", classifications[key]));
            }
        }
    }
}
