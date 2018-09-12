using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface INameFaker
    {
        string FullName();
        string FullName(NameFormats format);
        string First();
        string Last();
        string Prefix();
        string Suffix();
    }
    
    internal class NameFaker : INameFaker
    {
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<NameFormats> _nameFormats;
        private readonly IDictionary<NameFormats, Func<string[]>> _formatMappings;

        public NameFaker()
            : this(new ResourceWrapper())
        {
        }
        
        internal NameFaker(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
            _nameFormats = new List<NameFormats>
            {
                NameFormats.WithPrefix, NameFormats.WithSuffix, NameFormats.Standard
            };
            _formatMappings = new Dictionary<NameFormats, Func<string[]>>
            {
                { NameFormats.Standard,     () => new [] { First(), Last() } },
                { NameFormats.WithPrefix,   () => new [] { Prefix(), First(), Last() } },
                { NameFormats.WithSuffix,   () => new [] { First(), Last(), Suffix() } }
            };
        }
        
        public string FullName()
        {
            return FullName(_nameFormats.ElementAt(RandomNumber.Next(_nameFormats.Count() - 1)));
        }

        public string FullName(NameFormats format)
        {
            return string.Join(" ", _formatMappings[format].Invoke());
        }

        public string First()
        {
            return _resourceWrapper.Name.First.Split(Config.Separator).Random().Trim();
        }

        public string Last()
        {
            return _resourceWrapper.Name.Last.Split(Config.Separator).Random().Trim();
        }

        public string Prefix()
        {
            return _resourceWrapper.Name.Prefix.Split(Config.Separator).Random();
        }

        public string Suffix()
        {
            return _resourceWrapper.Name.Suffix.Split(Config.Separator).Random();
        }
    }
}