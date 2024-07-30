using Domain.Repositories;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        ISoldierMovementRepository _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new SoldierMovementRepository();
        }

        [Test]
        public void WhenLoadingPositionOfNotRegisteredSoldierThenThrowException()
        {
            //TODO: Implement this test
            Assert.Fail();
        }

        [Test]
        public void WhenSoldierHasNoPositionRecordsThenThrowException()
        {
            //TODO: Implement this test
            Assert.Fail();
        }

        [Test]
        public void WhenSoldierHasPositionRecordsThenReturnLastOne()
        {
            //TODO: Implement this test
            Assert.Fail();
        }
    }
}