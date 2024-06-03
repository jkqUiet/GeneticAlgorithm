using System;
using System.Collections.Generic;
using System.Text;

namespace MetaSemestralka
{
    public class Selector
    {

        Random rand;
        public Selector()
        {
            rand = new Random();
        }
        public List<int[]> select(Dictionary<int, Vrchol> vrcholy, List<int[]> population, Evaluator eva)
        {
            List<int[]> selected = new List<int[]>();
            float fitness = 0;

            // nascitavam celkovy fitness
            foreach (var auto in population)
            { 
              fitness += eva.getUcelFunkcia(auto, vrcholy);
            }

            float varFitness = 0;

            float[][] pravdepodobnosti = new float[population.Count][];
            int index = 0;
            foreach (var auto in population)
            {
                pravdepodobnosti[index] = new float[2];
                pravdepodobnosti[index][0] = varFitness / fitness;
                varFitness += eva.getUcelFunkcia(auto, vrcholy);
                pravdepodobnosti[index][1] = varFitness / varFitness;
                index++;
            }

            float r = (float)rand.NextDouble() % 1 / population.Count;
            float rjClen = 0.0f;
            for (int i = 0; i < pravdepodobnosti.Length; i++)
            {
                rjClen = r + (i / (float)population.Count);
                index = 0;
                for(int j = 0; j < pravdepodobnosti.Length; j++)
                {
                    if (pravdepodobnosti[j][1] > rjClen && rjClen > pravdepodobnosti[j][0])
                    {
                   
                        int[] v123 = new int[population[i].Length]; population[j].CopyTo(v123,0);
                        selected.Add(v123);
                        break;
                    }
                }
            }

            selected.Sort((v1, v2)=>eva.getUcelFunkcia(v1, vrcholy).CompareTo(eva.getUcelFunkcia(v2, vrcholy)));

            int sCount = selected.Count;
            for (int i = 0; i < sCount- 2; i++)
            {
                selected.RemoveAt(2);
            }
            return selected;
        }
    }
}
