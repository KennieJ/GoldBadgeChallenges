using System;
using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsRepoTests
{
    [TestClass]
    public class RepoTests
    {
        private ClaimsRepository _repo;
        private Claims _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _claim = new Claims("1", ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            _repo.AddClaimToQueue(_claim);
        }

        [TestMethod]
        public void AddClaimToQueue_ShouldNotGetNull()
        {
            //arrange
            Claims newClaim = new Claims();
            ClaimsRepository repository = new ClaimsRepository();
            newClaim.ClaimID = "13";

            //act
            repository.AddClaimToQueue(newClaim);
            Claims claimFromQueue = repository.GetClaimByID("13");

            //assert
            Assert.IsNotNull(claimFromQueue);
        }

        [TestMethod]
        public void RemoveClaimFromQueue_ShouldReturnTrue()
        {
            //arrange (in test initialize)
            //act
            bool deleteClaim = _repo.RemoveClaimFromQueue();

            //assert
            Assert.IsTrue(deleteClaim);
        }
    }
}
