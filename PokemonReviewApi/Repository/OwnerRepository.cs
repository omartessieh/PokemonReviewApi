using PokemonReviewApi.Data;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Owners//
        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        //Get Owner By Owner ID//
        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        //Get Pokemon By Owner ID//
        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        //Get Owner Of A Pokemon By Pokemon ID//
        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        //Owner Exists By ID//
        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        //Create Owner//
        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        //Update Owner//
        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }

        //Delete Owner//
        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
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