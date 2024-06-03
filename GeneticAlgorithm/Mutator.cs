using System;
using System.Collections.Generic;
using System.Text;

namespace MetaSemestralka
{

    public class Mutator
    {
        double hranicnaHodnota;
        Random rand;
        public Mutator(double hranicna)
        {
            hranicnaHodnota = hranicna;
            rand = new Random();
        }
        
        public void mutuj(int[] jedinec)
        {
            if (rand.NextDouble() < hranicnaHodnota) return;
            int prvy = rand.Next(0, jedinec.Length);
            int druhy = rand.Next(0, jedinec.Length);
            while (druhy == prvy) druhy = rand.Next(0, jedinec.Length);         
            (jedinec[prvy], jedinec[druhy]) = (jedinec[druhy], jedinec[prvy]);
        }
    }
}
