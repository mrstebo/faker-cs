using System;
using System.Collections.Generic;
using Faker.Extensions;
using Faker.Wrappers;

namespace Faker
{
    public interface IAddress
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
    
    internal class Address : IAddress
    {
        private readonly IResourceWrapper _resourceWrapper;
        private readonly IEnumerable<Func<string>> _cityFormats;
        private readonly IEnumerable<Func<string[]>> _streetFormats;
        private readonly IEnumerable<Func<string>> _streetAddressFormats;
        
        public Address()
            : this(new ResourceWrapper())
        {
        }

        internal Address(IResourceWrapper resourceWrapper)
        {
            _resourceWrapper = resourceWrapper;
            _cityFormats = new List<Func<string>>
            {
                () => string.Format("{0} {1}{2}", CityPrefix(), Name.First(), CitySufix()),
                () => string.Format("{0} {1}", CityPrefix(), Name.First()),
                () => string.Format("{0}{1}", Name.First(), CitySufix()),
                () => string.Format("{0}{1}", Name.Last(), CitySufix())
            };
            _streetFormats = new List<Func<string[]>>
            {
                () => new[] {Name.Last(), StreetSuffix()},
                () => new[] {Name.First(), StreetSuffix()}
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
            Random rnd = new Random();
            double lat = Math.Round((rnd.NextDouble()*170)- 85, 4); // between -85 to 85
            double lng = Math.Round((rnd.NextDouble()*360) - 180, 4); // between -180 to 180
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