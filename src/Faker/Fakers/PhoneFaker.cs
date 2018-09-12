using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface IPhoneFaker
    {
        string Number();
        string Number(string pattern);
    }
    
    internal class PhoneFaker : IPhoneFaker
    {
        private readonly IResourceWrapper _resourceWrapper;

        public PhoneFaker()
            : this(new ResourceWrapper())
        {
        }

        internal PhoneFaker(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
        }
        
        public string Number()
        {
            return _resourceWrapper.Phone.Formats.Split(Config.Separator).Random().Trim().Numerify();
        }

        public string Number(string pattern)
        {
            return pattern.Trim().Numerify();
        }
    }
}