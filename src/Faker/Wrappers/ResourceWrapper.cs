namespace Faker.Wrappers
{
    internal interface IResourceWrapper
    {
        IAddressResource Address { get; }
    }
    
    internal class ResourceWrapper : IResourceWrapper
    {
        public IAddressResource Address { get; } = new AddressResource();
    }
}