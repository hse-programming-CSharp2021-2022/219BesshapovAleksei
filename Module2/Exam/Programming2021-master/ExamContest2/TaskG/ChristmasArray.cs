using System;

internal class ChristmasArray : BaseArray
{
    public ChristmasArray(int[] array) : base(array)
    {

    }
    public override int this[int number]
    {
        get
        {
            int n = -1;
            int diff = -1;
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] > number)
                {
                    if (diff == -1)
                    {
                        n = this.array[i];
                        diff = this.array[i] - number;
                    }
                    else
                    {
                        if (diff > this.array[i] - number)
                        {
                            n = this.array[i];
                            diff = this.array[i] - number;
                        }
                    }
                   
                }
            }
            if (n == -1)
            {
                throw new ArgumentException("Number does not exist.");
            }
            return n;
        }
    }
    public override double GetMetric()
    {
        double odd = 0;
        double len = 0;
        for (int i = 0; i < this.array.Length; i++)
        {
            len += this.array[i].ToString().Length;
            odd += this.array[i] % 2 == 0 ? 1 : 0;
        }
        return odd / len;
    }
}