namespace BlazorSeverApp.Infrastructure
{
    public class ApplicationConstants
    {
        public enum ApiTypes { GET, POST, PUT, DELETE }

        public static string ProductApiUrl { get; set; }
        public static string CouponApiUrl { get; set; }
        public static string AuthApiUrl { get; set; }
        public static string CartApiUrl { get; set; }

        public class Roles
        {
            public const string Admins = "Admins";
            public const string Customers = "Customers";
        }

        //public const string RoleAdmins = "Admins";
        //public const string RoleCustomers = "Customers";

        public const string AuthTokenName = "AuthToken";
        public const string AuthCookieName = "AuthCookie";

    }
}
