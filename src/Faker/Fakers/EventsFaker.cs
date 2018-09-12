using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface IEvents
    {
        string Activity();
        string Season();
        string Name();
    }
    
    internal class EventsFaker : IEvents
    {
        private readonly IResourceWrapper _resourceWrapper;

        public EventsFaker()
            : this(new ResourceWrapper())
        {
        }

        internal EventsFaker(IResourceWrapper resourceWrapper)
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