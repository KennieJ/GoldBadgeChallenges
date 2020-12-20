using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_BadgesRepository;

namespace _03_BadgesConsole
{
    class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        private List<string> _doorList = new List<string>();
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            Badge exampleBadge1 = new Badge(12345, new List<string> { "A7", "B5", "C5" });
            Badge exampleBadge2 = new Badge(54321, new List<string> { "A7", "B5", "F5" });

            _repo.AddBadgeToDictionary(exampleBadge1);
            _repo.AddBadgeToDictionary(exampleBadge2);
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin. What would yo like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateABadge();
                        break;
                    case "2":
                        UpdateABadge();
                        break;
                    case "3":
                        DisplayDoorList();
                        break;
                    case "4":
                        Console.WriteLine("Over and Out.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                            break;
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private void CreateABadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            Console.WriteLine("What is the number on the badge?:");
            string badgeIDString = Console.ReadLine();
            int badgeIDInt = int.Parse(badgeIDString);
            newBadge.BadgeID = badgeIDInt;

            bool askForDoor = true;

            Console.WriteLine("List a door it needs access to:");
            string newDoor = Console.ReadLine();
            _doorList.Add(newDoor);
            
            while (askForDoor)
            {
                Console.WriteLine("Any other doors? (y/n):");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "y":
                        Console.WriteLine("List a door it needs access to:");
                        string newDoor2 = Console.ReadLine();
                        _doorList.Add(newDoor2);
                        break;
                    case "n":
                        askForDoor = false;
                        break;
                    default:
                        Console.WriteLine("Please enter y or n");
                        break;
                }
            }
            newBadge.DoorNames = _doorList;

            _repo.AddBadgeToDictionary(newBadge);
        }

        private void UpdateABadge()
        {
            Console.WriteLine("What is the badge number to update?:");
            string badgeIDString = Console.ReadLine();
            int badgeIDInt = int.Parse(badgeIDString);

            Badge newBadge = _repo.GetBadgeByID(badgeIDInt);

            Console.Clear();
            Console.WriteLine($"{newBadge.BadgeID} has access to doors");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");

            string input = Console.ReadLine();

            if(input == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                string badDoor = Console.ReadLine();
                bool wasDeleted = _repo.RemoveDoorFromBadge(badgeIDInt, badDoor);

                if (wasDeleted)
                {
                    Console.Clear();
                    Console.WriteLine($"Door removed.\n" +
                        $"{newBadge.BadgeID} has access to door(s) \n");
                }
                else
                {
                    Console.WriteLine("Door was not removed");
                }
            }
            else if(input == "2")
            {
                Console.WriteLine("What door would you like to add?");
                string newDoor = Console.ReadLine();
                bool wasAdded = _repo.AddDoorToBadge(badgeIDInt, newDoor);

                if (wasAdded)
                {
                    Console.WriteLine($"Door added.\n" +
                        $"{newBadge.BadgeID} has access to door(s) {newBadge.DoorNames}");
                }
                else
                {
                    Console.WriteLine("Door was not added");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }

            
        }

        private void DisplayBadgeDictionary()
        {
            Console.Clear();

            Dictionary<int, Badge> badgeDictionary = _repo.GetAllBadges();

            foreach(var badge in badgeDictionary)
            {
                Console.WriteLine(badge.Key);
                //DisplayDoorList(badge.Value);
            }
        }

        private void DisplayDoorList()
        {
            Dictionary<int, Badge> badgeDictionary = _repo.GetAllBadges();
            List<string> _doorList = _repo.GetDoorList();
            var doorstring = string.Join(",", _doorList);

            foreach(var badge in badgeDictionary)
            {
                Console.WriteLine($"{badge.Key}\t{doorstring}");
            }

            //foreach(string door in _doorList)
            //{
            //    Console.WriteLine(door);
            //}
        }
    }
}
