using System;
using System.Collections.Generic;
using _03_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesRepoTests
{
    [TestClass]
    public class RepoTests
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            _badge = new Badge(12345, new System.Collections.Generic.List<string> { "A5", "B6", "C3" });
            _badgeRepo.AddBadgeToDictionary(_badge);
        }

        [TestMethod]
        public void GetBadgeByID_ShouldNotGetNull()
        {
            //arranged in test initialize
            //act
            Badge badge = _badgeRepo.GetBadgeByID(12345);

            //assert
            Assert.IsNotNull(badge);
        }

        [TestMethod]
        public void AddBadge_ShouldNotGetNull()
        {
            //arrange
            Badge newBadge = new Badge(23456, new List<string> { "A5", "B2" });
            BadgeRepository repository = new BadgeRepository();

            //act
            repository.AddBadgeToDictionary(newBadge);
            Badge badgeFromDictionary = repository.GetBadgeByID(23456);

            //assert
            Assert.IsNotNull(badgeFromDictionary);
            Console.WriteLine(newBadge.DoorNames);
        }

        [TestMethod]
        public void AddDoorToBadge_ShouldReturnTrue()
        {
            //arranged in test initialize
            //act
            bool doorAdded = _badgeRepo.AddDoorToBadge(_badge.BadgeID, "Z4");

            //assert
            Assert.IsTrue(doorAdded);
        }

        [TestMethod]
        public void RemoveDoor_ShouldReturnTrue()
        {
            //arranged in test initialize
            //act
            bool doorRemoved = _badgeRepo.RemoveDoorFromBadge(_badge.BadgeID, "A5");

            //assert
            Assert.IsTrue(doorRemoved);
        }
    }
}
