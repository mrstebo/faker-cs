using System;
using System.Collections.Generic;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker
{
    public interface ICompany
    {
        string Name();
        string Suffix();
        string CatchPhrase();
        string BS();
    }
    
    internal class Company : ICompany
    {
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<Func<string>> _nameFormats;

        public Company()
            : this(new ResourceWrapper())
        {
        }

        internal Company(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
            _nameFormats = new List<Func<string>>
            {
                () => string.Format("{0} {1}", Faker.Name.Last(), Suffix()),
                () => string.Format("{0}-{1}", Faker.Name.Last(), Faker.Name.Last()),
                () => string.Format("{0}, {1} {2} {3}", Faker.Name.Last(), Faker.Name.Last(),
                    _resourceWrapper.Company.And,
                    Faker.Name.Last()),
            };
        }
        
        public string Name()
        {
            return _nameFormats.Random();
        }

        public string Suffix()
        {
            return _resourceWrapper.Company.Suffix.Split(Config.Separator).Random();
        }

        /// <summary>
        /// Generate a buzzword-laden catch phrase.
        /// Wordlist from http://www.1728.com/buzzword.htm
        /// </summary>
        public string CatchPhrase()
        {
            return string.Join(" ",
                               new[]
                               {
                                   _resourceWrapper.Company.Buzzwords1.Split(Config.Separator).Random(),
                                   _resourceWrapper.Company.Buzzwords2.Split(Config.Separator).Random(),
                                   _resourceWrapper.Company.Buzzwords3.Split(Config.Separator).Random()
                               });
        }

        /// <summary>
        /// When a straight answer won't do, BS to the rescue!
        /// Wordlist from http://dack.com/web/bullshit.html
        /// </summary>
        public string BS()
        {
            return string.Join(" ",
                               new[]
                               {
                                   _resourceWrapper.Company.BS1.Split(Config.Separator).Random(),
                                   _resourceWrapper.Company.BS2.Split(Config.Separator).Random(),
                                   _resourceWrapper.Company.BS3.Split(Config.Separator).Random()
                               });
        }
    }
}