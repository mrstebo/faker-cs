using System.Globalization;
using System.Threading;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests
{
    /// <summary>
    /// Creating a new CultureInfo (like 'en-bork' from the original Ruby Faker gem) requires windows *admin privileges* according to
    /// http://msdn.microsoft.com/en-us/library/ms172469(v=VS.85).aspx
    /// That's why 
    ///     (1) we take en-US as default and 
    ///     (2) require de-DE to have an 'extra word' at the beginning of the list within the resx file. 
    ///         In other words: This 'extra word' must differ from the first word in the default (en-US) resx file.
    /// 
    /// And no, we can't access Resource files from another dll directly.
    /// </summary>
    [TestFixture]
    public class CultureInfoFixture
    {
        [SetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            
            _lorem = new LoremFaker(new ResourceWrapper());
        }

        private ILorem _lorem;

        [Test]
        public void Should_Be_Default()
        {
            var expected = _lorem.GetFirstWord();
            var actual = _lorem.GetFirstWord();
            Assert.AreEqual(expected, actual);
        }
    }
}
