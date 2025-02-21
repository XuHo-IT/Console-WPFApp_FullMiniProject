using System;
using System.Collections.Generic;

namespace Question2
{
    public partial class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly MembershipDate { get; set; }

        public string Gender { get; set; } = null!; // Add Gender property

        public string Position { get; set; } = null!; // Add Position property

        public virtual ICollection<BorrowTransaction> BorrowTransactions { get; set; } = new List<BorrowTransaction>();
    }
}
