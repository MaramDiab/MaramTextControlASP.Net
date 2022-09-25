namespace MaramTX.Views.Home
{
    public static class Server
    {

        public static string MapPath(string path)
        {
            return Path.Combine((string)AppDomain.CurrentDomain.GetData("C:/Users/user/source/repos/test.txt"), path);
        }
    }
}
