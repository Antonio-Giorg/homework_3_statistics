using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormForExcercise
{
    internal class Adversary
    {
        // Attributes
        protected int N { get; private set; }
        protected int M { get; private set; }
        protected double P { get; private set; }

        // This list represents the history of all N attacks for all M systems
        protected List<List<int>> lineChartValuesChart1 { get; private set; }
        protected List<List<int>> lineChartValuesChart2 { get; private set; }
        protected List<List<double>> lineChartValuesChart3 { get; private set; }
        protected List<List<double>> lineChartValuesChart4 { get; private set; }


        // Constructor
        public Adversary(int m, int n, double p)
        {
            M = m;
            N = n;
            P = p;
            lineChartValuesChart1 = new List<List<int>>();
            lineChartValuesChart2 = new List<List<int>>();
            lineChartValuesChart3 = new List<List<double>>();
            lineChartValuesChart4 = new List<List<double>>();
        }

        // Method to generate attacks
        public bool generateAttacks()
        {
            Random random = new Random();

            for (int i = 0; i < M; i++)
            {
                List<int> valuesChart1 = new List<int>();
                List<int> valuesChart2 = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    // Generate random from (0, 1]
                    double randomNumber = random.NextDouble();

                    if (randomNumber > P)
                    {
                        // Attacck success
                        //Debug.WriteLine("System " + i + ": Attack" + j + " succeeded");
                        valuesChart1.Add(-1);
                        valuesChart2.Add(1);
                    }
                    else
                    {
                        // Attacco failed
                        //Debug.WriteLine("System " + i + ": Attack" + j + " failed");
                        valuesChart1.Add(+1);
                        valuesChart2.Add(0);
                    }
                }
                lineChartValuesChart1.Add(valuesChart1);
                lineChartValuesChart2.Add(valuesChart2);
            }

            createChart3Values();
            createChart4Values();

            return true;
        }

        private bool createChart3Values()
        {

            for (int i = 0; i < lineChartValuesChart2.Count; i++)
            {
                List<double> systemIValues = new List<double>();
                double sum = 0;
                //Debug.WriteLine("System " + i);
                for (int j = 0; j < lineChartValuesChart2[i].Count; j++)
                {
                    sum += lineChartValuesChart2[i][j];
                    systemIValues.Add(sum / (j + 1));
                    //Debug.WriteLine("Frequency (relative) values: " + sum / (j + 1));
                }
                lineChartValuesChart3.Add(systemIValues);
            }

            return true;
        }

        private bool createChart4Values()
        {

            for (int i = 0; i < lineChartValuesChart2.Count; i++)
            {
                List<double> systemIValues = new List<double>();
                double sum = 0;
                //Debug.WriteLine("System " + i);
                for (int j = 0; j < lineChartValuesChart2[i].Count; j++)
                {
                    sum += lineChartValuesChart2[i][j];
                    systemIValues.Add(sum / Math.Sqrt(j + 1));
                    //Debug.WriteLine("Frequency (normalized) values: " + sum / Math.Sqrt(j + 1));
                }
                lineChartValuesChart4.Add(systemIValues);
            }

            return true;
        }

        public List<List<int>> GetLineChart1AttackList()
        {
            return lineChartValuesChart1;
        }

        public List<List<int>> GetLineChart2AttackList()
        {
            return lineChartValuesChart2;
        }

        public List<List<double>> GetLineChart3AttackList()
        {
            return lineChartValuesChart3;
        }

        public List<List<double>> GetLineChart4AttackList()
        {
            return lineChartValuesChart4;
        }
    }
}
