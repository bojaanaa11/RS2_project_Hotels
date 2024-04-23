using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rating.Domain.Common;

namespace Rating.Domain.ValueObjects
{
    public class RatingInformation(int rating, string comment, DateTime? ratingDate) : ValueObject
    {
        public int Rating { get; private set; } = rating;
        public string Comment { get; private set; } = comment ?? throw new ArgumentNullException(nameof(comment));

        public DateTime? RatingDate { get; private set; } = ratingDate ?? throw new ArgumentNullException(nameof(ratingDate));

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Rating;
            yield return Comment;
            yield return RatingDate;
        }
    }
}