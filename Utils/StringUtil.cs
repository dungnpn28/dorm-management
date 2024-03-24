namespace DormitoryManagement.Utils
{
    public static class StringUtil
    {
        public static string GetUserName(string mail)
        {
            var a = mail.Split('@');
            return a[0].ToLower();
        }

        public static string GetStudentCode(string mail)
        {
            var a = mail.Split('@');
            return a[0].Substring(a[0].Length - 8).ToLower();
        }
    }
}
