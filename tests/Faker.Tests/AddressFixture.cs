using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class AddressFixture
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
            _address = new Address(new ResourceWrapper());
        }

        private IAddress _address;

        [Test]
        public void Should_Get_Street_Address()
        {
            var address = _address.StreetAddress();
            Assert.IsTrue(Regex.IsMatch(address, "^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+$"));
        }

        [Test]
        public void Should_Get_Street_Address_With_Secondary_Address()
        {
            var address = _address.StreetAddress(true);
            Assert.IsTrue(Regex.IsMatch(address, @"^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+\.? [0-9]{3}$"));
        }

        [Test]
        public void Should_Get_Random_Location()
        {
            var latlng = _address.LatLng();
            Assert.IsTrue(latlng.Lat >= -85);
            Assert.IsTrue(latlng.Lat <= 85);

            Assert.IsTrue(latlng.Lng >= -180);
            Assert.IsTrue(latlng.Lng <= 180);
        }

    }
}
