using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoRepo
{
    public class InsuranceRepo
    {
        private Dictionary<int, Badges> _dictionaryBadges = new Dictionary<int, Badges>();

        //Create
        public void AddBadgestoDict(Badges newBadge)
        {
            _dictionaryBadges.Add(newBadge.BadgeId, newBadge);
            
        }
        public void AddDoorsToBadge(Badges badge, string anotherDoor)
        {
            badge.DoorNames.Add(anotherDoor);
        }
        //Read
        public Dictionary<int, Badges> GetEntireDict()
        {
            return _dictionaryBadges;
        }
        //Update
        public bool UpdateDict(int badgeId, Badges newBadge)
        {
            return true;
        }
        //Delete
        public void DelDoorFromBadge(Badges badge, string removeDoor)
        {
            badge.DoorNames.Remove(removeDoor);
        }
        public void GetList()
        {
           


        }
        public Badges GetBadgeById(int badgeId)
        {
            foreach (Badges badge in _dictionaryBadges.Values)
            {
                if (badge.BadgeId == badgeId)
                {
                    return badge;
                }
            }
            return null;
        }
    }
}
