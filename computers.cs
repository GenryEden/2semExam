namespace computers
{
    internal class Program
    {
        public struct SComputer
        {
            uint[] drives;

            public SComputer(uint[] Drives)
            {
                drives = Drives;
            }

            public uint summaryMemorySize()
            {
                uint ans = 0;
                foreach (uint drive in drives) ans += drive;
                return ans;
            }
        }

        static void Main(string[] args)
        {
            List<SComputer> computers = new List<SComputer>();
            computers.Add(new SComputer(new uint[] {1,1}));
            computers.Add(new SComputer(new uint[] {2}));
            computers.Add(new SComputer(new uint[] { 1, 1, 1 }));
            computers.Add(new SComputer(new uint[] { 1, 1, 1 }));
            computers.Add(new SComputer(new uint[] { 1, 2, 1 }));
            computers.Add(new SComputer(new uint[] { 1, 1, 3 }));
            computers.Add(new SComputer(new uint[] { 1, 1, 1, 1, 1, 1 }));


            Console.WriteLine(findNumOfComputer(2, computers));
        }

        static uint findNumOfComputer(uint memorySize, List<SComputer> computers)
        {
            int left = 0, right = computers.Count;
            

            while (left < right - 1)
            {
                int mid = (left + right) / 2;
                uint current = computers[mid].summaryMemorySize();
                if (current == memorySize) return (uint) mid;

                if (current < memorySize) left = mid; 
                else right = mid;
            }

            if (computers[left].summaryMemorySize() != memorySize)
            {
                throw new Exception("There is no such computer!");
            }
            return (uint) left;

        }
    }
}