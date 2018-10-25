namespace UnitTesting.FullFx
{
    public class Values
    {
        public int Maximum(int[] values)
        {
            int max = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }
    }
}
