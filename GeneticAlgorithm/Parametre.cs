using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MetaSemestralka
{
    public class Parametre
    {
        private int generationCount;
        Dictionary<int, Vrchol> data;
        private List<int[]> generations;
        private int nodeCount;
        private List<int[]> elitePopulation;
        private int eliteSize;
        private int countOfO;
        private int zacVrchol;

        public Dictionary<int, Vrchol> Data { get => data; set => data = value; }
        public List<int[]> Generations { get => generations; set => generations = value; }
        public List<int[]> ElitePopulation { get => elitePopulation; set => elitePopulation = value; }
        public int EliteSize { get => eliteSize; set => eliteSize = value; }
        public int GenerationCount { get => generationCount; set => generationCount = value; }

        public Parametre(int pPopulacii, int eliteSizePar, int countOfOrder, int zVrchol)
        {
            nodeCount = 0;
            Generations = new List<int[]>();
            Data = new Dictionary<int, Vrchol>();
            GenerationCount = pPopulacii;
            ElitePopulation = new List<int[]>();
            EliteSize = eliteSizePar;
            countOfO = countOfOrder;
            zacVrchol = zVrchol;
        }
        public void vytvorPopulaciu(List<int[]> populacia)
        {
            Generations.Clear();
            int index = 0;
            if (ElitePopulation.Count > 0)
            {
                for (int i = 0; i < elitePopulation.Count; i++)
                {
                    Generations.Add(new int[elitePopulation[0].Length]);
                }
                foreach (var auto in ElitePopulation)
                {
                    for (int i = 0; i < auto.Length; i++)
                    {
                        Generations[index][i] = auto[i];
                    }
                    index++;
                }
            }
            index = Generations.Count;
            int co = 0;
            while (Generations.Count < generationCount) {
                Generations.Add(new int[elitePopulation[0].Length]);
                for (int i = 0; i < Generations[index].Length; i++)
                {
                    Generations[index][i] = populacia[co][i];
                }
                index++;
                co++;
            }
            Console.Write("");
        }
        public void vytvorPopulaciu()
        {
            List<int> vrcholy = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < GenerationCount -2; i++)
            {       
                foreach(var v in Data)
                {
                    if (v.Key == zacVrchol) { continue; }
                    vrcholy.Add(v.Key);
                }
                nodeCount = vrcholy.Count + 1;
                Generations.Add(new int[nodeCount]);
                Generations[i][0] = zacVrchol;
                for (int j = 1; j < nodeCount - 1; j++)
                {
                    int vIndex = rand.Next(0, vrcholy.Count);
                    Generations[i][j] = vrcholy[vIndex];
                    vrcholy.RemoveAt(vIndex);
                }
                Generations[i][nodeCount - 1] = Generations[i][0];
                vrcholy.Clear();
            }
        }

        public void nacitaj(string s1, string s2, string s3) {
            var f = new StreamReader(s1);
            var f1 = new StreamReader(s2);
            var f2 = new StreamReader(s3);
            f1.ReadLine();
            f.ReadLine();
            f2.ReadLine();
            
            while(!f.EndOfStream || !f1.EndOfStream)
            {
                int varVzd = Int32.Parse(f.ReadLine());
                Vrchol varVrch = new Vrchol(varVzd, f1.ReadLine());    
                Data.Add(varVzd,varVrch);
            }
            int vVrcholy = Int32.Parse(f2.ReadLine());
            foreach (var v in Data)
            {
                foreach(var g in Data)
                {
                    v.Value.MaticaVzdialenosti.Add(g.Key, Int32.Parse(f2.ReadLine()));                 
                }
            }


            f.Close();
            f1.Close();
            f2.Close();
        }
        public List<int[]> getGeneracie()
        {
            return Generations;
        }

        public Dictionary<int, Vrchol> getData()
        {
            return Data;
        }
    }
}
