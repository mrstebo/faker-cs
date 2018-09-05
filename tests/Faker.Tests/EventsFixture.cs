using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Faker.Wrappers;

namespace Faker.Tests
{
    [TestFixture]
    public class EventsFixture
    {
        [SetUp]
        public void SetUp()
        {
            _events = new Events(new ResourceWrapper());
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
