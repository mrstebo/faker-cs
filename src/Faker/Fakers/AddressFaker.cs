using System;
using System.Collections.Generic;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker.Fakers
{
    public interface IAddressFaker
    {
        string Country();
        string ZipCode();
        string UsState();
        string UsStateAbbr();
        string CityPrefix();
        string CitySufix();
        string City();
        string StreetSuffix();
        string StreetName();
        string StreetAddress(bool includeSecondary = false);
        string SecondaryAddress();
        string UkCounty();
        string UkCountry();
        string UkPostCode();
        LatLng LatLng();
    }
    
    internal class AddressFaker : IAddressFaker
    {
        private readonly IFaker _faker;
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<Func<string>> _cityFormats;
        private readonly IEnumerable<Func<string[]>> _streetFormats;
        private readonly IEnumerable<Func<string>> _streetAddressFormats;
        
        public AddressFaker(IFaker faker)
            : this(faker, new ResourceWrapper())
        {
        }

        internal AddressFaker(IFaker faker, IResourceWrapper resourceWrapper)
        {
            _faker = faker;
            _resourceWrapper = resourceWrapper;
            _cityFormats = new List<Func<string>>
            {
                () => string.Format("{0} {1}{2}", CityPrefix(), _faker.Name.First(), CitySufix()),
                () => string.Format("{0} {1}", CityPrefix(), _faker.Name.First()),
                () => string.Format("{0}{1}", _faker.Name.First(), CitySufix()),
                () => string.Format("{0}{1}", _faker.Name.Last(), CitySufix())
            };
            _streetFormats = new List<Func<string[]>>
            {
                () => new[] {_faker.Name.Last(), StreetSuffix()},
                () => new[] {_faker.Name.First(), StreetSuffix()}
            };
            _streetAddressFormats = new List<Func<string>>
            {
                () => string.Format(_resourceWrapper.Address.AddressFormat.Split(Config.Separator).Random().Trim(), StreetName())
            };
        }

        public string Country()
        {
            return _resourceWrapper.Address.Country.Split(Config.Separator).Random().Trim();
        }

        public string ZipCode()
        {
            return _resourceWrapper.Address.ZipCode.Split(Config.Separator).Random().Trim().Numerify();
        }

        public string UsState()
        {

            return _resourceWrapper.Address.UsState.Split(Config.Separator).Random().Trim();
        }

        public string UsStateAbbr()
        {
            return _resourceWrapper.Address.UsStateAbbr.Split(Config.Separator).Random();
        }

        public string CityPrefix()
        {
            return _resourceWrapper.Address.CityPrefix.Split(Config.Separator).Random();
        }

        public string CitySufix()
        {
            return _resourceWrapper.Address.CitySufix.Split(Config.Separator).Random();
        }

        public string City()
        {
            return _cityFormats.Random();
        }

        public string StreetSuffix()
        {
            return _resourceWrapper.Address.StreetSuffix.Split(Config.Separator).Random();
        }

        public string StreetName()
        {
            return string.Join(_resourceWrapper.Address.StreetNameSeparator, _streetFormats.Random());
        }

        public string StreetAddress(bool includeSecondary = false)
        {
            return _streetAddressFormats.Random().Numerify() + (includeSecondary ? " " + SecondaryAddress() : "");
        }

        public string SecondaryAddress()
        {
            return _resourceWrapper.Address.SecondaryAddress.Split(Config.Separator).Random().Trim().Numerify();
        }

        public string UkCounty()
        {
            return _resourceWrapper.Address.UkCounties.Split(Config.Separator).Random().Trim();
        }

        public string UkCountry()
        {
            return _resourceWrapper.Address.UkCountry.Split(Config.Separator).Random().Trim();
        }

        public string UkPostCode()
        {
            return _resourceWrapper.Address.UkPostCode.Split(Config.Separator).Random().Trim().Numerify().Letterify();
        }

        public LatLng LatLng()
        {
            var rnd = new Random();
            var lat = Math.Round((rnd.NextDouble()*170)- 85, 4); // between -85 to 85
            var lng = Math.Round((rnd.NextDouble()*360) - 180, 4); // between -180 to 180
            return new LatLng(lat, lng);
        }
    }

    public class LatLng
    {
        public double Lat { get; }
        public double Lng { get; }

        public LatLng(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }
}