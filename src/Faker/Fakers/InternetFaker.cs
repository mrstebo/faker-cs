using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface IInternetFaker
    {
        string Email();
        string Email(string name);
        string FreeEmail();
        string UserName();
        string UserName(string name);
        string DomainName();
        string DomainWord();
        string DomainSuffix();
        string IPv4Address();
        string IPv6Address();
        string Url();
    }
    
    internal class InternetFaker : IInternetFaker
    {
        private readonly IFaker _faker;
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<Func<string>> _userNameFormats;
        private readonly Random _random;

        public InternetFaker(IFaker faker)
            : this(faker, new ResourceWrapper())
        {
        }

        internal InternetFaker(IFaker faker, IResourceWrapper resourceWrapper)
        {
            _faker = faker;
            _resourceWrapper = resourceWrapper;
            _userNameFormats = new List<Func<string>>
            {
                () => _faker.Name.First().AlphanumericOnly().ToLowerInvariant(),
                () => string.Format("{0}{1}{2}", _faker.Name.First().AlphanumericOnly(), 
                    new [] { ".", "_" }.Random(), _faker.Name.Last().AlphanumericOnly()).ToLowerInvariant()
            };
            _random = new Random();
        }

        public string Email()
        {
            return string.Format("{0}@{1}", UserName(), DomainName());
        }

        public string Email(string name)
        {
            return string.Format("{0}@{1}", UserName(name), DomainName());
        }

        public string FreeEmail()
        {
            return string.Format("{0}@{1}", UserName(), _resourceWrapper.Internet.FreeMail.Split(Config.Separator).Random());
        }

        public string UserName()
        {
            return _userNameFormats.Random();
        }

        public string UserName(string name)
        {
            return Regex.Replace(name, @"[^\w]+", x => new [] { ".", "_" }.Random(), RegexOptions.Compiled).ToLowerInvariant();
        }

        public string DomainName()
        {
            return string.Format("{0}.{1}", DomainWord(), DomainSuffix());
        }

        public string DomainWord()
        {
            return _faker.Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        public string DomainSuffix()
        {
            return _resourceWrapper.Internet.DomainSuffix.Split(Config.Separator).Random();
        }

        public string IPv4Address()
        {
            const int min = 2;
            const int max = 255;
            string[] parts = {
                _random.Next(min, max).ToString(),
                _random.Next(min, max).ToString(),
                _random.Next(min, max).ToString(),
                _random.Next(min, max).ToString(),
            };
            return string.Join(".", parts);
        }

        public string IPv6Address()
        {
            const int min = 0;
            const int max = 65536;
            var parts = Enumerable.Range(0, 8)
                .Select(_ => _random.Next(min, max).ToString("x").PadLeft(4, '0'))
                .ToArray();
            return string.Join(":", parts);
        }

        public string Url()
        {
            return string.Format("http://{0}/{1}", DomainName(), UserName());
        }
    }
}