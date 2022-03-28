namespace BraviTest.BalancedBrackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            string brackets;
            do
            {
                Console.WriteLine("Type your brackets sequence for validation or ENTER to leave...");
                brackets = Console.ReadLine();

                if (Validation.CheckBracketsSequence(brackets.ToArray()))
                {
                    Console.WriteLine("This is a valid sequence!");
                }
                else
                {
                    Console.WriteLine("The sequence you entered is not valid!");
                }
            } while (brackets != "" );
        }


    }
}