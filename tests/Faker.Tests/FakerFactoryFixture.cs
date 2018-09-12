using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class FakerFactoryFixture
    {
        [Test]
        public void Create_returns_an_IFaker()
        {
            Assert.IsInstanceOf<IFaker>(FakerFactory.Create());
        }
    }
}