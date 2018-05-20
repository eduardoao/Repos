using System;

namespace DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Imposto iss = new ISS();

            Orcamento orcamento = new Orcamento(500);


            var imposto =  calculaImposto(orcamento, iss);
            Console.Write(imposto);
            Console.ReadKey();


        }

        private static double calculaImposto(Orcamento orcamento, Imposto imposto)
        {
            return imposto.calcula(orcamento);
        }
    }


    public interface Imposto
    {
        double calcula(Orcamento orcamento);
    }


    public class ICMS : Imposto
    {
        public double calcula(Orcamento orcamento)
        {
            return orcamento.getValor() * 0.05 + 50;
        }
    }

    public class ISS : Imposto
    {
        public double calcula(Orcamento orcamento)
        {
            return orcamento.getValor() * 0.06;
        }
    }

}
