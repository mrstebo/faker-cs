namespace Faker.Wrappers
{
    internal interface IResourceWrapper
    {
        IAddressResource Address { get; }
        ICompanyResource Company { get; }
    }
    
    internal class ResourceWrapper : IResourceWrapper
    {
        public IAddressResource Address { get; } = new AddressResource();
        public ICompanyResource Company { get; } = new CompanyResource();
    }
}