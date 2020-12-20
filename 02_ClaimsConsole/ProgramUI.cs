using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_ClaimsRepository;

namespace _02_ClaimsConsole
{
    class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Seed()
        {
            Claims example1 = new Claims("1", ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018,4,25), new DateTime(2018, 4, 27), true);
            Claims example2 = new Claims("2", ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claims example3 = new Claims("3", ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _claimsRepo.AddClaimToQueue(example1);
            _claimsRepo.AddClaimToQueue(example2);
            _claimsRepo.AddClaimToQueue(example3);
        }

        private void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Choose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Close menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayClaimsQueue();
                        break;
                    case "2":
                        ShowNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

            }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
        }

        private void DisplayClaimsQueue()
        {
            Console.Clear();
            Queue<Claims> claimsQueue = _claimsRepo.GetClaimsQueue();

            Console.WriteLine($"ClaimID\tType\tDescription\t\tAmount\tDateOfAccident\tDateOfClaim\tIsValid");
            
            foreach(Claims claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID}\t{claim.Type}\t{claim.Description}\t${claim.ClaimAmount}\t{claim.DateOfIncident:d}\t" +
                    $"{claim.DateOfClaim:d}\t{claim.IsValid}");
            }
                Console.WriteLine("");
        }

        private void ShowNextClaim()
        {
            Console.Clear();
            Queue<Claims> claimsQueue = _claimsRepo.GetClaimsQueue();
            Claims nextClaim =  claimsQueue.Peek();

            Console.WriteLine($"Here are the details of the next claim to be handled:\n" +
                $"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.Type}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"DateOfAccident: {nextClaim.DateOfIncident:d}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim:d}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n" +
                $"Do you want to deal with this claim now (y/n)?");

            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                bool dequeueCheck = _claimsRepo.RemoveClaimFromQueue();

                if (dequeueCheck)
                {
                    Console.Clear();
                    Console.WriteLine("Claim has been removed from queue\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Claim has not been removed from queue\n");
                }
            }
            else if(input.ToLower() == "n")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Please enter y or n");
            }
        }

        private void CreateNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.Type = (ClaimType)typeAsInt;

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Amount of damage (exclude '$'):");
            string claimAmountAsString = Console.ReadLine();
            double claimAmountAsDouble = double.Parse(claimAmountAsString);
            newClaim.ClaimAmount = claimAmountAsDouble;

            Console.WriteLine("Date of Accident (YYYY,MM,DD):");
            string accidentDateString = Console.ReadLine();
            DateTime accidentDate = DateTime.Parse(accidentDateString);
            newClaim.DateOfIncident = accidentDate;

            Console.WriteLine("Date of Claim (YYYY,MM,DD):");
            string claimDateString = Console.ReadLine();
            DateTime claimDate = DateTime.Parse(claimDateString);
            newClaim.DateOfClaim = claimDate;

            TimeSpan timeSinceAccident = new TimeSpan();
            timeSinceAccident = claimDate - accidentDate;
            
            if(timeSinceAccident.TotalDays > 30)
            {
                newClaim.IsValid = false;
            }
            else
            {
                newClaim.IsValid = true;
            }

            _claimsRepo.AddClaimToQueue(newClaim);
        }
    }
}
