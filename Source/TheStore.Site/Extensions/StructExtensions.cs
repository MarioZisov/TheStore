namespace TheStore.Site.Extensions
{
    using TheStore.Site.Resources.PagesTexts;

    public static class StructExtensions
    {
        public static string AsText(this bool value)
        {
            if (value)
                return GlobalTexts.Boolean_True;

            return GlobalTexts.Boolean_False;
        }
    }
}