using PokemonReviewApi.Data;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Countries//
        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        //Get Country By ID//
        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        //Get Country By Owner ID//
        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        //Get Owners From A Country By Country ID//
        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        //Country Exists By ID//
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        //Create Country//
        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        //Update Country//
        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }

        //Delete Country//
        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }

        //Save Methode//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}