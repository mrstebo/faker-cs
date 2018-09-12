﻿namespace Faker
{
    public interface IFaker
    {
        IAddress Address { get; }
        ICompany Company { get; }
        IEvents Events { get; }
        ILorem Lorem { get; }
    }
    
    internal class FakerInstance : IFaker
    {
        public IAddress Address { get; }
        public ICompany Company { get; }
        public IEvents Events { get; }
        public ILorem Lorem { get; }

        internal FakerInstance()
        {
            Address = new Address();
            Company = new Company();
            Events = new Events();
            Lorem = new Lorem();
        }
    }
}