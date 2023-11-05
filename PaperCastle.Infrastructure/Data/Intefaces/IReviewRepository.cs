using PaperCastle.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();

        Review GetReviewById(int id);

        ICollection<Review> GetReviewsOfBook(int bookId);

        ICollection<Review> GetUsersReviews(string userId);

        bool ReviewExists(int id);

        bool CreateReview(Review review);

        bool UpdateReview(Review review);

        bool DeleteReviews(List<Review> reviews);

        bool DeleteReview(Review review);

        bool Save();
    }
}
