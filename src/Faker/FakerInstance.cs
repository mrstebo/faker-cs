﻿using Faker.Fakers;

namespace Faker
{
    public interface IFaker
    {
        IAddressFaker Address { get; }
        ICompanyFaker Company { get; }
        IEventsFaker Events { get; }
        ILoremFaker Lorem { get; }
    }
    
    internal class FakerInstance : IFaker
    {
        public IAddressFaker Address { get; }
        public ICompanyFaker Company { get; }
        public IEventsFaker Events { get; }
        public ILoremFaker Lorem { get; }

        internal FakerInstance()
        {
            Address = new AddressFaker();
            Company = new CompanyFaker();
            Events = new EventsFaker();
            Lorem = new LoremFaker();
        }
    }
}