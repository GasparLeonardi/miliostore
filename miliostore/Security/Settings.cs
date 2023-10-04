namespace miliostore.Security
{
    public class Settings
    {
        private static string secret = "88dbd9b321cf627dc391c044583007f2ae6eaeb74ac52395f3483f3c00cfae6e";

        public static string Secret { get => secret; set => secret = value; }
    }
}
