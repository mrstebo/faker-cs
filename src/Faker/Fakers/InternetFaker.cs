﻿using System;
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
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<Func<string>> _userNameFormats;
        private readonly Random _random;

        public InternetFaker()
            : this(new ResourceWrapper())
        {
        }

        internal InternetFaker(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
            _userNameFormats = new List<Func<string>>
            {
                () => Name.First().AlphanumericOnly().ToLowerInvariant(),
                () => string.Format("{0}{1}{2}", Name.First().AlphanumericOnly(), 
                    new [] { ".", "_" }.Random(), Name.Last().AlphanumericOnly()).ToLowerInvariant()
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
            return string.Format("{0}@{1}", UserName(), Resources.Internet.FreeMail.Split(Config.Separator).Random());
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
            return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        public string DomainSuffix()
        {
            return Resources.Internet.DomainSuffix.Split(Config.Separator).Random();
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
            return String.Join(".", parts);
        }

        public string IPv6Address()
        {
            const int min = 0;
            const int max = 65536;
            string[] parts = {
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
                _random.Next(min, max).ToString("x"),
            };
            return string.Join(":", parts);
        }

        public string Url()
        {
            return string.Format("http://{0}/{1}", DomainName(), UserName());
        }
    }
}