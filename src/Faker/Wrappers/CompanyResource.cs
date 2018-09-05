namespace Faker.Wrappers
{
    public interface ICompanyResource
    {
        string And { get; }
        string Suffix { get; }
        string Buzzwords1 { get; }
        string Buzzwords2 { get; }
        string Buzzwords3 { get; }
        string BS1 { get; }
        string BS2 { get; }
        string BS3 { get; }
    }
    
    internal class CompanyResource : ICompanyResource
    {
        public string And => Resources.Company.And;
        public string Suffix => Resources.Company.Suffix;
        public string Buzzwords1 => Resources.Company.Buzzwords1;
        public string Buzzwords2 => Resources.Company.Buzzwords2;
        public string Buzzwords3 => Resources.Company.Buzzwords3;
        public string BS1 => Resources.Company.BS1;
        public string BS2 => Resources.Company.BS2;
        public string BS3 => Resources.Company.BS3;
    }
}