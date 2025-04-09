namespace Manual_Mapper
{
    public interface ICurrentUserBusiness
    {

        string GetCurrentUserId();
        string GetCurrentUserRole();

    }
    public class FakeCurrentUserBusiness : ICurrentUserBusiness
    {
        // This is a fake implementation used for testing or demo purposes.
        // In a real project, these methods would retrieve data from an authentication framework or user context.
        public string GetCurrentUserId()
        {
            return "00000000-0000-0000-0000-000000000001"; 
        }

        public string GetCurrentUserRole()
        {
            return "Admin";
        }

     
    }
}