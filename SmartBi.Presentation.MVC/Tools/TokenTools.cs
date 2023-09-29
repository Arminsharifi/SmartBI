namespace SmartBi.Presentation.MVC.Tools
{
    public static class TokenTools
    {
        public static async string? GetBearerToken(ISession session)
        {
            string? Token = session.GetString("BearerToken");
            if (Token == null)
            {
                await Signo
                return null;
            }
        }
    }
}
