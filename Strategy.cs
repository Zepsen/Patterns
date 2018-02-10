using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
                // var ctx = new PaymentContext((EStrategy)1);
                // ctx.Execute();

            System.Console.WriteLine("Select strategy");            
            ConsoleKeyInfo key;
            do {
                //while (!Console.KeyAvailable) {
                    key = Console.ReadKey();
                    System.Console.WriteLine();                    
                    if(int.TryParse(key.KeyChar.ToString(), out var n))
                    {
                        if (Enum.IsDefined(typeof(EStrategy), n)) {
                            var ctx = new PaymentContext((EStrategy)n);
                            ctx.Execute();
                        }
                        else System.Console.WriteLine("Wrong type");
                        
                        
                    }                    
                //}       
            } while (key.Key != ConsoleKey.Escape);            
        }
    }
}

public enum EStrategy 
{
    Card = 1, 
    Balance = 2,
    Custom = 3
}

public class PaymentContext
{
    IStrategy strategy;
    private Dictionary<EStrategy, IStrategy> dic = new Dictionary<EStrategy, IStrategy>
    {
        { EStrategy.Card, new Card()},
        { EStrategy.Balance, new Balance()},
        { EStrategy.Custom, new Custom()}
    };

    public PaymentContext(IStrategy str)
    {
        strategy = str;
    }

    public PaymentContext(EStrategy str)
    {
        strategy = dic[str];
    }

    public void Execute()
    {
        strategy.Algoritm();
    }
}

public interface IStrategy
{
    void Algoritm();
}

public class Card : IStrategy
{
    void IStrategy.Algoritm()
    {
        System.Console.WriteLine("Card");
    }
}

public class Balance : IStrategy
{
    void IStrategy.Algoritm()
    {
        System.Console.WriteLine("Balance");
    }
}

public class Custom : IStrategy
{
    void IStrategy.Algoritm()
    {
        System.Console.WriteLine("Custom");
    }
}