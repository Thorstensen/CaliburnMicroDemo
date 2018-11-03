namespace Caliburn.Micro.Demo.Companies.Module.Model
{
    public class Company
    {
        public Company(string companyName, string country)
        {
            CompanyName = companyName;
            Country = country;
        }

        public string CompanyName { get; }
        public string Country { get; }
    }
}
