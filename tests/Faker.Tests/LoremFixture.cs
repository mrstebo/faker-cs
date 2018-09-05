using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class LoremFixture
    {
        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
            _lorem = new Lorem(new ResourceWrapper());
        }

        private ILorem _lorem;
        
        [Test]
        public void Should_Return_Word_List()
        {
            var words = _lorem.Words(10);
            Assert.AreEqual(10, words.Count());
        }

        [Test]
        public void Should_Generate_Random_Word_Sentence()
        {
            var sentence = _lorem.Sentence();
            Assert.IsTrue(Regex.IsMatch(sentence, @"[A-Z][a-z ]+\."));
        }

        [Test]
        public void Should_Generate_Paragraph()
        {
            var para = _lorem.Paragraph();
            Assert.IsTrue(Regex.IsMatch(para, @"([A-Z][a-z ]+\.\s?){3,6}"));
        }
    }
}