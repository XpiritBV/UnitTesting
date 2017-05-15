using System.Text;

namespace UnitTesting.ClassLibrary
{
    public static class LinkFactory
    {
        public static Link CreateOne()
        {
            return new Link(1);
        }

        public static Link CreateTwo()
        {
            return null;// new Link(2);
        }

        public static Link CreateThree()
        {
            return new Link(3);
            //return null; //TODO: implement this!
        }
    }
}
