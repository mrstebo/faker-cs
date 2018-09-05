namespace Faker.Wrappers
{
    internal interface IResourceWrapper
    {
        IAddressResource Address { get; }
        ICompanyResource Company { get; }
        IEventsResource Events { get; }
    }

    internal class ResourceWrapper : IResourceWrapper
    {
        public IAddressResource Address { get; } = new AddressResource();
        public ICompanyResource Company { get; } = new CompanyResource();
        public IEventsResource Events { get; } = new EventsResource();
    }
}