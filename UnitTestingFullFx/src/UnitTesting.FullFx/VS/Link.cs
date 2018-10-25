namespace UnitTesting.ClassLibrary
{
    public class Link
    {
        public int Position { get; }

        public Link(int position) => Position = position;

        public Link AddBlueLink()
        {
            if (Position > 2) return null;

            return new Link(Position + 1);
        }

        public Link AddRedLink()
        {
            //TODO: implement this!
            return null;
        }

        public Link AddYellowLink()
        {
            if (Position > 2) return null;

            return new Link(Position + 1);
        }

        public Link AddGreenLink()
        {
            if (Position > 2) return null;

            return new Link(Position + 1);
        }
    }
}
