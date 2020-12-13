using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoRepo
{
    public class InsuranceRepo
    {
        private Dictionary<int, List<string>> _dictionaryBadges = new Dictionary<int, List<string>>();
        //Create
        public void AddBadgestoDict(int badgeId, List<string> listOfDoors)
        {
            _dictionaryBadges.Add(badgeId, listOfDoors);
        }
        //Read
        public Dictionary<int, List<string>> GetEntireDict()
        {
            return _dictionaryBadges;
        }
        //Update
        public bool UpdateDict(int badgeId, Badges newBadge)
        {

        }
        //Delete
        public void DeleteDictEntry(int badgeId)
        {
            _dictionaryBadges.Remove(badgeId);
        }
        //Helper by BadgeId?
        //public Badges GetBadgeById(int badgeId)
        //{
        //    foreach(Dictionary<int,Badges>.KeyCollection keys in _dictionaryBadges.Keys)
        //    {
        //        if(key.BadgeId == badgeId)
        //        {
        //            return key;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
