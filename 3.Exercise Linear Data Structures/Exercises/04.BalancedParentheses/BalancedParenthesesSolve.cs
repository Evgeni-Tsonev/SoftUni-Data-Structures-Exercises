namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            var parenthesesArray = parentheses.ToCharArray();
            var parenthesesStack = new Stack<char>();

            foreach (var bracket in parenthesesArray)
            {
                if (bracket == '(' ||
                    bracket == '{' ||
                    bracket == '[')
                {
                    parenthesesStack.Push(bracket);
                    continue;
                }

                if (parenthesesStack.Count > 0)
                {
                    var lastBracket = parenthesesStack.Pop();

                    if (bracket == ')')
                    {
                        if (lastBracket != '(')
                        {
                            return false;
                        }
                    }
                    else if (bracket == '}')
                    {
                        if (lastBracket != '{')
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (lastBracket != '[')
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
