namespace theAlkashOfTheRIngs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String etalon = Console.ReadLine();
            String ethanolString = Console.ReadLine();

            Console.WriteLine(isCorrect(etalon, ethanolString));
        }

        static bool isCorrect(String etalon, String ethanol)
        {
            while (etalon.Length < ethanol.Length)
            {
                etalon += etalon;
            }
            etalon += etalon;
            char[] ethanolChars = ethanol.ToCharArray();
            Array.Reverse(ethanolChars);
            String lonahte = new String(ethanolChars);
            return etalon.Contains(ethanol) || etalon.Contains(lonahte);
        }
    }
}