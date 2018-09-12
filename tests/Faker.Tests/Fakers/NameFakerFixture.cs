using System.Text.RegularExpressions;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests.Fakers
{
    [TestFixture]
    public class NameFakerFixture
    {
        [SetUp]
        public void SetUp()
        {
            _name = new NameFaker(new ResourceWrapper());
        }

        private INameFaker _name;
        
        [Test]
        public void Should_Get_FullName()
        {
            var name = _name.FullName();
            Assert.IsTrue(Regex.IsMatch(name, @"^(\w+\.? ?){2,3}$"));
        }

        [Test]
        public void Should_Get_FullName_With_Standard_Format()
        {
            var name = _name.FullName(NameFormats.Standard);
            Assert.IsTrue(Regex.IsMatch(name, @"^\w+\.? \w+\.?$"));
        }

        [Test]
        public void Should_Get_Prefix()
        {
            var prefix = _name.Prefix();
            Assert.IsTrue(Regex.IsMatch(prefix, @"^[A-Z][a-z]+\.?$"));
        }

        [Test]
        public void Should_Get_Suffix()
        {
            var suffix = _name.Suffix();
            Assert.IsTrue(Regex.IsMatch(suffix, @"^[A-Z][A-Za-z]*\.?$"));
        }
    }
}