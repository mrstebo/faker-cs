﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Fakers;
using Faker.Wrappers;
using NUnit.Framework;

namespace Faker.Tests.Fakers
{
    [TestFixture]
    public class CompanyFakerFixture
    {
        [SetUp]
        public void SetUp()
        {
            _company = new CompanyFaker(new ResourceWrapper());
        }

        private ICompany _company;
        
        [Test]
        public void Should_Generate_Company_Name()
        {
            var name = _company.Name();

            // Name should match one of the given formats
            Assert.IsTrue(new List<Func<bool>>
                              {
                                  () => Regex.IsMatch(name, @"\w+ \w+"),
                                  () => Regex.IsMatch(name, @"\w+-\w+"),
                                  () => Regex.IsMatch(name, @"\w+, \w+ and \w+")
                              }.Any(x => x.Invoke()));
        }

        [Test]
        public void Should_Generate_Catchphrase()
        {
            var catchPhrase = _company.CatchPhrase();
            Assert.IsTrue(Regex.IsMatch(catchPhrase, @"[\w\-]+ [\w\-]+ [\w\-]+"));
        }

        [Test]
        public void Should_Generate_Bs()
        {
            var bs = _company.BS();
            Assert.IsTrue(Regex.IsMatch(bs, @"[\w\-]+ [\w\-]+ [\w\-]+"));
        }
    }
}
