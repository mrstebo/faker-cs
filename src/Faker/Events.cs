using Faker.Extensions;
using Faker.Wrappers;

namespace Faker
{
    public interface IEvents
    {
        string Activity();
        string Season();
        string Name();
    }
    
    internal class Events : IEvents
    {
        private readonly IResourceWrapper _resourceWrapper;

        public Events()
            : this(new ResourceWrapper())
        {
        }

        internal Events(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
        }

        public string Activity()
        {
            return _resourceWrapper.Events.Activity.Split(Config.Separator).Random();
        }
        public string Season()
        {
            return _resourceWrapper.Events.Season.Split(Config.Separator).Random();
        }


        /// <summary>
        /// Generate a buzzword-laden catch phrase.
        /// Wordlist from http://www.1728.com/buzzword.htm
        /// </summary>
        public string Name()
        {
            return string.Join(" ",
                               new[]
                               {
                                   _resourceWrapper.Events.Season.Split(Config.Separator).Random(),
                                   _resourceWrapper.Events.Activity.Split(Config.Separator).Random(),
                               });
        }


    }
}