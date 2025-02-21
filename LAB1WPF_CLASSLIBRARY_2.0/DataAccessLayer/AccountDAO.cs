using BusinessObjects;

namespace DataAccessLayer
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountID)
        {
            AccountMember accountMember = new AccountMember();
            if (accountID.Equals("PS0001")) // just for demonstration
            {
                accountMember.MemberId = accountID;
                accountMember.MemberPassword = "123";  // Ensure this is not null
                accountMember.MemberRole = 1;
            }
            else
            {
                // Handle the case where the account is not found
                accountMember = null;
            }

            return accountMember;
        }
    }
}
