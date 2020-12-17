using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingsRepo
{
    public class OutingRepository
    {
        List<Outings> listOfOutings = new List<Outings>();
        public void AddOutingToList(Outings newOuting)
        {
            listOfOutings.Add(newOuting);
        }
        public List<Outings> SeeOutingsList()
        {
            return listOfOutings;
        }
        public double TestCostPerType(enumEventTypes test1)
        {
            double test = 0;
            foreach(Outings outings in listOfOutings)
            {
                //filter so that only one enumEventType passes through
                test += outings.CostPerPerson * outings.NumberOfAttendees;
            }
            return test;
        }
        public Outings CostPerType()
        {
            foreach(Outings outings in listOfOutings)
            {
                outings.TotalCostPerType = outings.CostPerPerson * outings.NumberOfAttendees;
                return outings;
            }
            return null;
        }
        public void CostByTypeEvent()
        {
            foreach(Outings outings in listOfOutings)
            {
                outings.TotalCostPerType = outings.CostPerPerson * outings.NumberOfAttendees;
                Console.WriteLine($"{outings.TotalCostPerType:C2}");
            }
                Console.ReadLine();
        }
    }
}
