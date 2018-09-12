using Faker.Fakers;
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
            Assert.IsInstanceOf<IAddressFaker>(_faker.Address);
        }

        [Test]
        public void Company_returns_ICompany()
        {
            Assert.IsInstanceOf<ICompanyFaker>(_faker.Company);
        }

        [Test]
        public void Events_returns_IEvents()
        {
            Assert.IsInstanceOf<IEventsFaker>(_faker.Events);
        }

        [Test]
        public void Lorem_returns_ILorem()
        {
            Assert.IsInstanceOf<ILoremFaker>(_faker.Lorem);
        }
    }
}