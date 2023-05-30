using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfBook(int bookId)
        {
            return _context.Reviews.Where(r => r.Book.Id == bookId).ToList();
        }

        public ICollection<Review> GetUsersReviews(int userId)
        {
            return _context.Reviews.Where(r => r.ApplicationUserId == userId).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
