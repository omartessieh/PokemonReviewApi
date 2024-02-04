using PokemonReviewApi.Data;
using PokemonReviewApi.Entities;
using PokemonReviewApi.Interfaces;

namespace PokemonReviewApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get Reviews//
        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        //Get Review By Review ID//
        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        //Get Reviews Of A Pokemon By Pokemon ID//
        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        //Review Exists By Review ID//
        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        //Create Review//
        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }

        //Update Review//
        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }

        //Delete Review//
        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        //Delete Reviews//
        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
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