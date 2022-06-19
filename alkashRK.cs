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
            return isSubstringTwice(etalon, ethanol);
        }

        static bool isSubstringTwice(String etalon, String ethanol)
        {
            int hash = getHash(ethanol);
            char[] ethanolChars = ethanol.ToCharArray();
            Array.Reverse(ethanolChars);
            String lonahte = new String(ethanolChars);
            int subHash = getHash(etalon.Substring(0, ethanol.Length));
            int i;
            for (i = 1; i <= etalon.Length - ethanol.Length; i++)
            {
                if (subHash == hash)
                {
                    if (etalon.Substring(i - 1, ethanol.Length) == ethanol || etalon.Substring(i - 1, ethanol.Length) == lonahte)
                    {
                        return true;
                    }
                }

                subHash -= etalon[i - 1];
                subHash += etalon[i + ethanol.Length - 1];
            }

            if (etalon.Substring(i - 1, ethanol.Length) == ethanol || etalon.Substring(i - 1, ethanol.Length) == lonahte)
            {
                return true;
            }

            return false;

        }

        static int getHash(String s)
        {
            int ans = 0;
            foreach (char c in s)
            {
                ans += c;
            }

            return ans;
        }
    }
}