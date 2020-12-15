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
        public void AddDoorsToBadge(int badgeId, string anotherDoor)
        {
            Badges badge = GetBadgeById(badgeId);
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
            Badges oldBadge = GetBadgeById(badgeId);
            if (oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public void DelDoorFromBadge(int badgeId, string removeDoor)
        {
            Badges badge = GetBadgeById(badgeId);
            badge.DoorNames.Remove(removeDoor);
        }
        //Helper
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
