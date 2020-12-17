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
        public double TestCostPerType(enumEventTypes enumEvents)
        {
            double totalCost = 0;
            foreach (Outings outings in listOfOutings)
            {
                if (enumEvents == outings.EventTypes)
                {
                    totalCost = outings.CostPerPerson * outings.NumberOfAttendees;
                }
            }
            return totalCost;
        }
        public double TotalCostEvents()
        {
            double totalCost = 0;
            foreach (Outings outings in listOfOutings)
            {
                totalCost += outings.CostPerPerson * outings.NumberOfAttendees;
            }
            return totalCost;
        }
    }
}
