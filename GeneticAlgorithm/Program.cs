using System;

namespace MetaSemestralka
{
    class Program
    {
        static void Main(string[] args)
        {
            GenAlgo gen = new GenAlgo(30, 5);
            gen.solveProblem(100);
            gen.vypisCestu();
        }
    }
}
