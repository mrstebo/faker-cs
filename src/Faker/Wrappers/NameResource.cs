namespace Faker.Wrappers
{
    public interface INameResource
    {
        string First { get; }
        string Last { get; }
        string Prefix { get; }
        string Suffix { get; }
    }
    
    internal class NameResource : INameResource
    {
        public string First => Resources.Name.First;
        public string Last => Resources.Name.Last;
        public string Prefix => Resources.Name.Prefix;
        public string Suffix => Resources.Name.Suffix;
    }
}