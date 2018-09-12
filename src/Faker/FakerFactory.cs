namespace Faker
{
    public static class FakerFactory
    {
        public static IFaker Create() => new FakerInstance();
    }
}