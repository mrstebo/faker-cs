using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests.Fakers
{
    [TestFixture]
    public class EventsFakerFixture
    {
        [SetUp]
        public void SetUp()
        {
            _events = new EventsFaker(new ResourceWrapper());
        }

        private IEvents _events;
        
        [Test]
        public void Should_Generate_Name()
        {
            var name = _events.Name();

            // Name should match one of the given formats
            Assert.IsTrue(new List<Func<bool>>
                              {
                                  () => Regex.IsMatch(name, @"\w+ \w+"),
                                  () => Regex.IsMatch(name, @"\w+-\w+"),
                              }.Any(x => x.Invoke()));
        }

    }
}
