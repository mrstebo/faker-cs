namespace Faker.Wrappers
{
    public interface IInternetResource
    {
        string FreeMail { get; }
        string DomainSuffix { get; }
    }
    
    internal class InternetResource : IInternetResource
    {
        public string FreeMail => Resources.Internet.FreeMail;
        public string DomainSuffix => Resources.Internet.DomainSuffix;
    }
}