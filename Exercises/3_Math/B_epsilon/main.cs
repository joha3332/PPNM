using System;

namespace epsilon
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 1;
            while (i + 1 > i) { i++; }
            Console.Write("my max int = {0}\n", i);
            Console.Write("int.MaxValue = {0}\n", int.MaxValue);

            int j = 1;
            while (j - 1 < j) { j--; }
            Console.Write("my min int = {0}\n", j);
            Console.Write("int.MinValue = {0}\n", int.MinValue);

            double x = 1; while (1 + x != 1) { x /= 2; }
            x *= 2;
            Console.Write("min double = {0}\n", x);
            float y = 1F; while ((float)(1F + y) != 1F) { y /= 2F; }
            y *= 2F;
            Console.Write("min float = {0}\n", y);

            Console.Write("2^(-52) = {0}\n", System.Math.Pow(2, -52));
            Console.Write("2^(-23) = {0}\n", System.Math.Pow(2, -23));

            int max = int.MaxValue / 2;
            float float_sum_up = 1f;
            for (int k = 2; k < max; k++) float_sum_up += 1f / k;

            float float_sum_down = 1f/max;
            for (int l = max - 1; l > 0; l--) float_sum_down += 1f / l;

            Console.Write("float_sum_up={0}\n", float_sum_up);
            Console.Write("float_sum_down={0}\n", float_sum_down);

            double double_sum_up = 1.0;
            for (int k = 2; k < max; k++) double_sum_up += 1.0 / k;

            double double_sum_down = 1.0/max;
            for (int l = max - 1; l > 0; l--) double_sum_down += 1.0 / l;

            Console.Write("double_sum_up={0}\n", double_sum_up);
            Console.Write("double_sum_down={0}\n", double_sum_down);

        }
    }

}
