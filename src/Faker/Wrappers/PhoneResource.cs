namespace Faker.Wrappers
{
    public interface IPhoneResource
    {
        string Formats { get; }
    }
    
    internal class PhoneResource : IPhoneResource
    {
        public string Formats => Resources.Phone.Formats;
    }
}