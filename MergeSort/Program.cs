using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static Random rand;
        static void Main(string[] args)
        {
            rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int[] input = new int[rand.Next(1,101)];
                for (int j = 0; j < input.Length; j++)
                {
                    input[j] = rand.Next(1000);
                }
                int[] output = SplitToIndividual(input);
                //foreach (int val in input)
                //{
                //    Console.Write(val + " ");
                //}
                //Console.WriteLine();
                //foreach (int val in output)
                //{
                //    Console.Write(val + " ");
                //}
                //Console.WriteLine();
                Console.WriteLine(IsSorted(output));
            }
            //int[][] output = Split(input);
            //DisplayArray(output[0]);
            //Console.Write("\n");
            //DisplayArray(output[1]);
            Console.ReadKey();
        }
        public static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] SplitToIndividual(int[] input)
        {
            int[] output;
            int indexToAdd = 0;

            if (input.Length == 1)
            {
                return input;
            }
            else if (input.Length == 2)
            {
                if (input[0] > input[1])
                {
                    return new int[] { input[1], input[0] };
                }
                return new int[] { input[0], input[1] };
            }
            else
            {
                int[][] splitted = Split(input);
                int[] items1 = SplitToIndividual(splitted[0]);
                int[] items2 = SplitToIndividual(splitted[1]);

                output = new int[items1.Length + items2.Length];
                    int bottomsAdded = 0;
                    int topsAdded = 0;
                    for (int top = 0; top < items2.Length; top++)
                    {
                        for (int bottom = bottomsAdded; bottom < items1.Length; bottom++)
                        {
                            if (items2[top] > items1[bottom])
                            {
                                output[indexToAdd] = items1[bottom];
                                indexToAdd++;
                                bottomsAdded++;
                            }
                            else
                            {
                                output[indexToAdd] = items2[top];
                                indexToAdd++;
                                topsAdded++;
                                break;
                            }

                        }
                    }
                    for (int bottom = bottomsAdded; bottom < items1.Length; bottom++)
                    {
                        output[indexToAdd] = items1[bottom];
                        indexToAdd++;
                    }
                for (int top = topsAdded; top < items2.Length; top++)
                {
                    output[indexToAdd] = items2[top];
                    indexToAdd++;
                }
            }
            return output;
        }

        public static int[][] Split(int[] input)
        {
            int[] out1 = new int[(int)Math.Ceiling((decimal)(input.Length / 2f))];
            int[] out2 = new int[(int)(input.Length / 2f)];
            for (int i = 0; i < out1.Length; i++)
            {
                out1[i] = input[i];
            }
            for (int i = 0; i < out2.Length; i++)
            {
                out2[i] = input[i + out1.Length];
            }
            return new int[][] { out1, out2 };
        }


    }
}
