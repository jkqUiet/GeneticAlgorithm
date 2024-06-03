using System;
using System.Collections.Generic;
using System.Text;

namespace MetaSemestralka
{
    public class GenAlgo
    {
        Evaluator eva;
        Crosser crosser;
        Mutator mutator;
        Selector selector;
        Parametre parametre;

        public GenAlgo(int populationSize, int elitePopulationSize)
        {
            eva = new Evaluator();
            crosser = new Crosser();
            mutator = new Mutator(0.5);
            selector = new Selector();
            parametre = new Parametre(populationSize, elitePopulationSize, 1, 1995);
            parametre.nacitaj("../../../NR/S_CNR_0350_0001_J.txt", "../../../NR/S_CNR_0350_0001_N.txt", "../../../NR/S_CNR_0350_0002_D.txt");
            parametre.vytvorPopulaciu();
        }

        public void vypisCestu()
        {
            parametre.Generations.Sort((v1, v2) => eva.getUcelFunkcia(v1, parametre.Data).CompareTo(eva.getUcelFunkcia(v2, parametre.Data)));

            foreach (var auto in parametre.Generations[0])
            {
                Console.WriteLine(parametre.Data[auto].Nazov1);
            }
        }

        public void solveProblem(int mutationCount)
        {
            for (int i = 0; i < mutationCount; i++)
            {
                List<int[]> bestOfTheBest = new List<int[]>();
                while(bestOfTheBest.Count < parametre.GenerationCount)
                {
                    List<int[]> v = selector.select(parametre.Data, parametre.Generations,eva);

                    crosser.kriz(v[0], v[1]);
                   
                    mutator.mutuj(v[0]);
                    mutator.mutuj(v[1]);
                    if (eva.getUcelFunkcia(v[0],parametre.Data) > eva.getUcelFunkcia(v[1], parametre.Data))
                    {
                        bestOfTheBest.Add(v[1]);
                    } else
                    {
                        bestOfTheBest.Add(v[0]);
                    }
                    v.Clear();
                }

                parametre.Generations.Sort((v1, v2) => eva.getUcelFunkcia(v1, parametre.Data).CompareTo(eva.getUcelFunkcia(v2, parametre.Data)));
                parametre.ElitePopulation.Add(parametre.Generations[0]);
                if (parametre.ElitePopulation.Count > parametre.EliteSize)
                {
                    parametre.ElitePopulation.Sort((v1,v2)=>eva.getUcelFunkcia(v1, parametre.Data).CompareTo(eva.getUcelFunkcia(v2, parametre.Data)));
                    parametre.ElitePopulation.RemoveAt(parametre.ElitePopulation.Count-1);
                }
                parametre.vytvorPopulaciu(bestOfTheBest);

                Console.WriteLine("Hodnota Ucelovej funkcie je : " + eva.getUcelFunkcia(parametre.ElitePopulation[0], parametre.Data));  
            }
        }
    }
}
