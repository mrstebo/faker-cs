namespace Faker.Wrappers
{
    public interface ILoremResource
    {
        string Words { get; }
    }

    internal class LoremResource : ILoremResource
    {
        public string Words => Resources.Lorem.Words;
    }
}