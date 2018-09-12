using System.Text.RegularExpressions;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests.Fakers
{
    [TestFixture]
    public class PhoneFakerFixture
    {
        [SetUp]
        public void SetUp()
        {
            _phone = new PhoneFaker(new ResourceWrapper());
        }

        private IPhoneFaker _phone;
        
        [Test]
        public void Should_Generate_Phone_Number()
        {
            var number = _phone.Number();
            Assert.IsTrue(Regex.IsMatch(number, @"[0-9 x\-\(\)\.]+"));
        }

        [TestCase("01## ### ####", @"01[0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
        [TestCase("###-###-####", @"[0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]")]
        [TestCase("### ### ####", @"[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
        public void Should_Generate_Phone_Number_Based_On_Pattern(string pattern, string regexMatchPattern)
        {
            var number = _phone.Number(pattern);
            Assert.IsTrue(Regex.IsMatch(number, regexMatchPattern));
        }
    }
}