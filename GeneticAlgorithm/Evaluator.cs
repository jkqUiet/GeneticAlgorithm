using System;
using System.Collections.Generic;
using System.Text;

namespace MetaSemestralka
{
    public class Evaluator
    {
        public Evaluator()
        {
        }

        public int getUcelFunkcia(int[] sol, Dictionary<int, Vrchol> data)
        {
            int ucel = 0;

            for (int i = 0; i < sol.Length-1; i++)
            {
                try
                {
                    ucel += data[sol[i]].MaticaVzdialenosti[sol[i + 1]];
                } catch
                {
                    continue;
                }
            }
            return ucel;
        }
    }
}
