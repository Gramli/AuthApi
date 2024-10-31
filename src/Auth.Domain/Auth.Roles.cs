namespace Auth.Domain
{
    public static class AuthRoles
    {
        public static readonly string User = "user";
        public static readonly string Developer = "developer";
        public static readonly string Administrator = "administrator";
        public static readonly IEnumerable<string> AllRoles = [User, Developer, Administrator];


        public static bool IsAdministrator(this string role)
            => Administrator.Equals(role);
    }
}
