namespace Faker.Wrappers
{
    internal interface IResourceWrapper
    {
        IAddressResource Address { get; }
        ICompanyResource Company { get; }
        IEventsResource Events { get; }
        ILoremResource Lorem { get; }
        INameResource Name { get; }
        IPhoneResource Phone { get; }
    }

    internal class ResourceWrapper : IResourceWrapper
    {
        public IAddressResource Address { get; } = new AddressResource();
        public ICompanyResource Company { get; } = new CompanyResource();
        public IEventsResource Events { get; } = new EventsResource();
        public ILoremResource Lorem { get; } = new LoremResource();
        public INameResource Name { get; } = new NameResource();
        public IPhoneResource Phone { get; } = new PhoneResource();
    }
}