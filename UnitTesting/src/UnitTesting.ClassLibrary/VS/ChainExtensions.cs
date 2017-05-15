namespace UnitTesting.ClassLibrary
{
    public static class ChainExtensions
    {
        public static Chain AddLink(this Chain chain, Link link)
        {
            chain.Add(link);
            return chain;
        }
    }
}
