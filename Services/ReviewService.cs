using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Helpers;
using Backend.Models;
using Backend.Dtos;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Errors.Model;

namespace Backend.Services;

public class ReviewService
{
    private readonly AppDbContext _dbContext;

    public ReviewService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<Review>> GetAllReviewService(int currentPage, int pageSize)
    {
        var reviews = await _dbContext.Reviews
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return reviews;
    }

    public async Task<IEnumerable<Review>> GetAllProductReviewsService(
 string productId
)
    {
        var query = _dbContext.Reviews.AsQueryable();
        var productQuery = _dbContext.Products.AsQueryable();
        var product = await productQuery.FirstOrDefaultAsync(p => p.ProductId.ToString() == productId);

        if (product == null)
        {
            throw new NotFoundException($"No Product Found With Id: {productId}");
        }
        query = query.Where(r => r.ProductId == product.ProductId);

        var reviews = await query
            .ToListAsync();

        return reviews;
    }



    public async Task<Review?> GetReviewById(Guid reviewId)
    {
        return await _dbContext.Reviews.FindAsync(reviewId);
    }


    public async Task<Review> CreateReviewService(Review newReview)
    {
        var existingReview = await _dbContext.Reviews
            .FirstOrDefaultAsync(r =>
                r.ProductId == newReview.ProductId &&
                r.CustomerId == newReview.CustomerId &&
                r.OrderId == newReview.OrderId);

        if (existingReview != null)
        {
            throw new InvalidOperationException("A review with the same attributes already exists.");
        }

        newReview.ReviewId = Guid.NewGuid();
        newReview.ReviewDate = DateTime.UtcNow;
        _dbContext.Reviews.Add(newReview);
        await _dbContext.SaveChangesAsync();
        return newReview;
    }


    public async Task<Review?> UpdateReviewService(Guid reviewId, ReviewDto updateReview)
    {
        var existingReview = await _dbContext.Reviews.FindAsync(reviewId);
        if (existingReview != null)
        {
            existingReview.Status = updateReview.Status.IsNullOrEmpty() ? existingReview.Status : updateReview.Status;
            await _dbContext.SaveChangesAsync();
        }

        return existingReview;
    }


    public async Task<bool> DeleteReviewService(Guid reviewId)
    {
        var reviewToRemove = await _dbContext.Reviews.FindAsync(reviewId);
        if (reviewToRemove != null)
        {
            _dbContext.Reviews.Remove(reviewToRemove);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
    public async Task<int> GetTotalReviewCount()
    {
        return await _dbContext.Reviews.CountAsync();
    }
}