using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutingsRepo
{
    public enum enumEventTypes
    {
        Golf=1,
        Bowling,
        Amusement_Park,
        Concert
    }
    public class Outings
    {
        public enumEventTypes EventTypes { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostPerType { get; set; }
        public Outings() { }
        public Outings(double totalCostperType)
        {
            TotalCostPerType = totalCostperType;
        }
        public Outings(enumEventTypes eventTypes, int numberOfAttendees, DateTime dateOfEvent, double costPerPerson)
        {
            EventTypes = eventTypes;
            NumberOfAttendees = numberOfAttendees;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
        }
    }

}
