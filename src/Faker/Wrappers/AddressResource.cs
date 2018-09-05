namespace Faker.Wrappers
{
    public interface IAddressResource
    {
        string Country { get; }
        string ZipCode { get; }
        string UsState { get; }
        string UsStateAbbr { get; }
        string CityPrefix { get; }
        string CitySufix { get; }
        string StreetSuffix { get; }
        string SecondaryAddress { get; }
        string StreetNameSeparator { get; }
        string UkCounties { get; }
        string UkCountry { get; }
        string UkPostCode { get; }
        string AddressFormat { get; }
    }

    internal class AddressResource : IAddressResource
    {
        public string Country => Resources.Address.Country;
        public string ZipCode => Resources.Address.ZipCode;
        public string UsState => Resources.Address.UsState;
        public string UsStateAbbr => Resources.Address.UsStateAbbr;
        public string CityPrefix => Resources.Address.CityPrefix;
        public string CitySufix => Resources.Address.CitySufix;
        public string StreetSuffix => Resources.Address.StreetSuffix;
        public string SecondaryAddress => Resources.Address.SecondaryAddress;
        public string StreetNameSeparator => Resources.Address.StreetNameSeparator;
        public string UkCounties => Resources.Address.UkCounties;
        public string UkCountry => Resources.Address.UkCountry;
        public string UkPostCode => Resources.Address.UkPostCode;
        public string AddressFormat => Resources.Address.AddressFormat;
    }
}