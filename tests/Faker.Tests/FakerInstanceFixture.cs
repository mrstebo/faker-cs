using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class FakerInstanceFixture
    {
        [SetUp]
        public void SetUp()
        {
            _faker = new FakerInstance();
        }

        private IFaker _faker;

        [Test]
        public void Address_returns_IAddress()
        {
            Assert.IsInstanceOf<IAddress>(_faker.Address);
        }

        [Test]
        public void Company_returns_ICompany()
        {
            Assert.IsInstanceOf<ICompany>(_faker.Company);
        }

        [Test]
        public void Events_returns_IEvents()
        {
            Assert.IsInstanceOf<IEvents>(_faker.Events);
        }

        [Test]
        public void Lorem_returns_ILorem()
        {
            Assert.IsInstanceOf<ILorem>(_faker.Lorem);
        }
    }
}