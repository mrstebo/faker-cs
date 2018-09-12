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
        public void Address_returns_IAddressFaker()
        {
            Assert.IsInstanceOf<IAddressFaker>(_faker.Address);
        }

        [Test]
        public void Company_returns_ICompanyFaker()
        {
            Assert.IsInstanceOf<ICompanyFaker>(_faker.Company);
        }

        [Test]
        public void Events_returns_IEventsFaker()
        {
            Assert.IsInstanceOf<IEventsFaker>(_faker.Events);
        }

        [Test]
        public void Lorem_returns_ILoremFaker()
        {
            Assert.IsInstanceOf<ILoremFaker>(_faker.Lorem);
        }

        [Test]
        public void Internet_returns_IInternetFaker()
        {
            Assert.IsInstanceOf<IInternetFaker>(_faker.Internet);
        }

        [Test]
        public void Name_returns_INameFaker()
        {
            Assert.IsInstanceOf<INameFaker>(_faker.Name);
        }

        [Test]
        public void Phone_returns_IPhoneFaker()
        {
            Assert.IsInstanceOf<IPhoneFaker>(_faker.Phone);
        }
    }
}