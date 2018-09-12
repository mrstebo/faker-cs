using System.Text.RegularExpressions;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests.Fakers
{
    [TestFixture]
    public class InternetFakerFixture
    {
        [SetUp]
        public void SetUp()
        {
            _faker = new FakerInstance();
            _internet = new InternetFaker(_faker, new ResourceWrapper());
        }

        private IFaker _faker;
        private IInternetFaker _internet;
        
        [Test]
        public void Should_Create_Email_Address()
        {
            var email = _internet.Email();
            Assert.IsTrue(Regex.IsMatch(email, @".+@.+\.\w+"));
        }

        [Test]
        public void Should_Create_Email_Address_From_Given_Name()
        {
            var email = _internet.Email("Bob Smith");
            Assert.IsTrue(Regex.IsMatch(email, @"bob[_\.]smith@.+\.\w+"));
        }

        [Test]
        public void Should_Create_Free_Email()
        {
            var email = _internet.FreeEmail();
            Assert.IsTrue(Regex.IsMatch(email, @".+@(gmail|hotmail|yahoo)\.com"));
        }

        [Test]
        public void Should_Create_User_Name()
        {
            var username = _internet.UserName();
            Assert.IsTrue(Regex.IsMatch(username, @"[a-z]+((_|\.)[a-z]+)?"));
        }

        [Test]
        public void Should_Create_User_Name_From_Given_Name()
        {
            var username = _internet.UserName("Bob Smith");
            Assert.IsTrue(Regex.IsMatch(username, @"bob[_\.]smith"));
        }

        [Test]
        public void Should_Get_Domain_Name()
        {
            var domain = _internet.DomainName();
            Assert.IsTrue(Regex.IsMatch(domain, @"\w+\.\w+"));
        }

        [Test]
        public void Should_Get_Domain_Word()
        {
            var word = _internet.DomainWord();
            Assert.IsTrue(Regex.IsMatch(word, @"^\w+$"));
        }

        [Test]
        public void Should_Get_Domain_Suffix()
        {
            var suffix = _internet.DomainSuffix();
            Assert.IsTrue(Regex.IsMatch(suffix, @"^\w+(\.\w+)?"));
        }

        [Test]
        public void Should_Get_IPv4_Address()
        {
            var ip = _internet.IPv4Address();
            Assert.IsTrue(Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"));
        }

        [Test]
        public void Should_Get_IPv6_Address()
        {
            var ip = _internet.IPv6Address();
            Assert.IsTrue(Regex.IsMatch(ip, @"^[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}:[0-9a-f]{4}$"));
        }

        [Test]
        public void Should_Get_Url()
        {
            var url = _internet.Url();
            Assert.IsTrue(Regex.IsMatch(url, @"^http://"));
        }
    }
}