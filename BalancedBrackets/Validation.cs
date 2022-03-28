using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraviTest.BalancedBrackets
{
    public static class Validation
    {
        private static Dictionary<char, char> _bracketsPair = new Dictionary<char, char>()
        {
            { '[', ']' },
            { '(', ')' },
            { '{', '}' }
        };

        public static bool CheckBracketsSequence(char[] bracketSequence)
        {
            Stack<char> openingBrackets = new Stack<char>();
            
            foreach (var bracket in bracketSequence)
            {
                if (bracket == ']' || bracket == '}' || bracket == ')')
                {
                    if (bracket == _bracketsPair[openingBrackets.Peek()])
                    {
                        openingBrackets.Pop();
                    }
                }
                else
                {
                    openingBrackets.Push(bracket);
                }
            }

            return openingBrackets.Count == 0;
        }
    }
}
