//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MetaSemestralka
//{
//    public class Crosser
//    {
//        Random rand;
//        public Crosser()
//        {
//            rand = new Random();
//        }

//        public void kriz(int[] jedinec1, int[] jedinec2)
//        {
//            int[] maska = new int[jedinec1.Length]; maska[0] = 1; maska[maska.Length - 1] = 1;

//            int[] jedinec1Novy = new int[jedinec1.Length];
//            int[] jedinec2Novy = new int[jedinec2.Length];
//            jedinec1Novy[0] = jedinec1Novy[jedinec1Novy.Length - 1] = jedinec1[0];
//            jedinec2Novy[0] = jedinec2Novy[jedinec2Novy.Length - 1] = jedinec2[0];

//            for (int i = 1; i < maska.Length -1; i++)
//            {
//                maska[i] = rand.Next(0, 2);
//                if (maska[i] == 1)
//                {
//                    jedinec1Novy[i] = jedinec1[i];
//                    jedinec2Novy[i] = jedinec2[i];
//                } else
//                {
//                    jedinec1Novy[i] = -1;
//                    jedinec2Novy[i] = -1;
//                }
//            }

//            for (int i = 0; i < jedinec1Novy.Length; i++)
//            {
//                if (maska[i] == 1) { continue; }
//                for (int j = 0; j < jedinec1Novy.Length; j++)
//                {
//                    if (jedinec1Novy.Contains(jedinec2[j])) { continue; }
//                    else
//                    {
//                        jedinec1Novy[i] = jedinec2[j];
//                        break;
//                    }
//                }
//                for (int j = 0; j < jedinec2Novy.Length; j++)
//                {
//                    if (jedinec2Novy.Contains(jedinec1[j])) { continue; }
//                    else
//                    {
//                        jedinec2Novy[i] = jedinec1[j];
//                        break;
//                    }
//                }
//            }



//            for (int kl = 0; kl < jedinec1.Length; kl++)
//            {
//                if (jedinec1Novy[kl] == -1 || jedinec2Novy[kl] == -1)
//                {
//                    Console.WriteLine("  ");
//                }
//            }



//            for (int i = 0; i < jedinec1.Length; i++)
//            {
//                jedinec1[i] = jedinec1Novy[i];
//                jedinec2[i] = jedinec2Novy[i];
//            }


//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaSemestralka
{
    public class Crosser
    {
        Random _maskRNG;

        public Crosser()
        {
            _maskRNG = new Random();
        }

        public void kriz(int[] solution1, int[] solution2)
        {
            //Create mask
            bool[] mask = new bool[solution1.Length];
            for (int i = 1; i < mask.Length - 1; i++)
            {
                mask[i] = _maskRNG.NextDouble() < 0.5;
            }

            //Create deep copies
            int[] crossover1 = new int[solution1.Length];
            int[] crossover2 = new int[solution2.Length];
            for (int i = 0; i < solution1.Length; i++)
            {
                crossover1[i] = solution1[i];
                crossover2[i] = solution2[i];
            }

            //Remove masked spots
            for (int i = 0; i < solution1.Length; i++)
            {
                if (!mask[i]) { continue; }
                solution1[i] = -1;
                solution2[i] = -1;
            }

            //Crossover the solutions
            for (int i = 0; i < solution1.Length; i++)
            {
                if (!mask[i]) { continue; }
                for (int j = 0; j < solution1.Length; j++)
                {
                    if (solution1.Contains(crossover2[j])) { continue; }
                    else
                    {
                        solution1[i] = crossover2[j];
                        break;
                    }
                }
                for (int j = 0; j < solution2.Length; j++)
                {
                    if (solution2.Contains(crossover1[j])) { continue; }
                    else
                    {
                        solution2[i] = crossover1[j];
                        break;
                    }
                }
            }
        }
    }
}
