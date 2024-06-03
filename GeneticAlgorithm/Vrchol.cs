using System;
using System.Collections.Generic;
using System.Text;

namespace MetaSemestralka
{
    public class Vrchol
    {
        private int ID;
        private string Nazov;
      
        private Dictionary<int,int> maticaVzdialenosti;
      
        public int ID1 { get => ID; set => ID = value; }
        public string Nazov1 { get => Nazov; set => Nazov = value; }
        public Dictionary<int, int> MaticaVzdialenosti { get => maticaVzdialenosti; set => maticaVzdialenosti = value; }

        public Vrchol(int i, string n)
        {
            ID = i;
            Nazov1 = n;
            MaticaVzdialenosti = new Dictionary<int,int>();
        } 
    }
}
