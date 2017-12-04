using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        public static Queue<char> ShuntYardFun(string input)
        {
            Dictionary<char, int> Presidence = new Dictionary<char, int> { {'+', 2}, {'-', 2}, {'/', 3}, {'*', 3}};
            Queue<char> output = new Queue<char>();
            Stack<char> operatorStack = new Stack<char>();
            Queue<char> inputList = new Queue<char>();
            foreach(char token in input)
            {
                if(token !=  ' ' && (Char.IsNumber(token) || (token == '+'|| token == '-' || token == '/' || token == '*')))
                {
                    inputList.Enqueue(token);
                }
                else if(Char.IsLetter(token))
                    return output;
            }
            foreach(char token in inputList)
            {
                if(Char.IsNumber(token))
                {
                    output.Enqueue(token);
                }
                else
                {
                    while(operatorStack.Count != 0 && Presidence[operatorStack.Peek()] >= Presidence[token])
                    {
                        output.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }
            while(operatorStack.Count != 0)
            {
                output.Enqueue(operatorStack.Pop());
            }
            return output;
        }

        static void Main(string[] args)
        {
            string input = "3 + 4";
            foreach (char thing in ShuntYardFun(input))
            {
                Console.WriteLine(thing);
            }
        }
    }
}
