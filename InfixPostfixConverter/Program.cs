using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfixPostfixConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = Console.ReadLine().Replace(" ", String.Empty);
            Stack<char> stack = new Stack<char>();
            String operators = "+-*/()";

            foreach (char t in input)
            {
                // t is an operand
                if (operators.IndexOf(t) == -1)
                {
                    Console.Write(t);
                }
                else if (t == ')')
                {
                    while (true)
                    {
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            Console.Write(stack.Pop());
                        }
                    }
                }
                else
                {
                    while(true)
                    {
                        if (stack.Count == 0 || stack.Peek() == '(')
                        {
                            break;
                        }

                        // operator of lower precedence
                        if(operators.IndexOf(stack.Peek()) < operators.IndexOf(t))
                        {
                            break;
                        }

                        Console.Write(stack.Pop());
                    }
                    stack.Push(t);
                }
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.ReadLine();
        }
    }
}
