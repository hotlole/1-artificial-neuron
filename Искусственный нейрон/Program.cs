using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Искусственный_нейрон
{
    internal class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.00001m;
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input, decimal expectedResult) 
            { 
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }

        }



        static void Main(string[] args)
        {
            decimal usd = 1;
            decimal rub = 99.68m;

            Neuron neuron = new Neuron();


            int i = 0;

            do
            {
                i++;
                neuron.Train(usd, rub);
                if (i % 1000000 == 0)
                {
                    Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");
                }
            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("Обучение завершено!");

            Console.WriteLine($"{neuron.ProcessInputData(100)} rub в {100} usd");
            Console.WriteLine($"{neuron.ProcessInputData(541)} rub в {541} usd");
            Console.WriteLine($"{neuron.RestoreInputData(10)} usd в {10} rub");
        }
    }
}
