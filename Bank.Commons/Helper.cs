namespace Bank.Commons
{
    public static class Helper
    {
        public static string GenerateAccountNumber()
        {
            return DateTime.Now.ToString("yyyyMMddss");
        }
    }
}