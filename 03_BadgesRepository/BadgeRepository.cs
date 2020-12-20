using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class BadgeRepository
    {
        private Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        private List<string> _listOfDoors = new List<string>();

        //create
        public void AddBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge);
        }

        //read
        public Dictionary<int, Badge> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public List<string> GetDoorList()
        {
            return _listOfDoors;
        }
        
        //update
        public bool AddDoorToBadge(int badgeID, string newDoor)
        {
            //find
            Badge oldBadge = GetBadgeByID(badgeID);

            //update
            if(oldBadge != null)
            {
                oldBadge.DoorNames.Add(newDoor);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        //delete
        public bool RemoveDoorFromBadge(int badgeId, string badDoor)
        {
            //find
            Badge oldBadge = GetBadgeByID(badgeId);

            //delete
            if (oldBadge != null)
            {
                oldBadge.DoorNames.Remove(badDoor);
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper
        public Badge GetBadgeByID(int badgeIDinput)
        {
            foreach(var badge in _badgeDictionary)
            {
                if (_badgeDictionary.ContainsKey(badgeIDinput))
                {
                    int badgeID = badge.Key;
                    //string doorListString = badge.Value;
                    List<string> doorList = badge.Value.DoorNames;
                    
                    Badge returnBadge = new Badge(badgeID, doorList);
                    return returnBadge;
                }
            }

            return null;
        }
    }
}
