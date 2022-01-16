using System.IO;

namespace ListNodeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            // First List
            var firstList = new ListNode
            {
                Data = "firstObject"
            };

            // Second List
            var secondList = new ListNode
            {
                Data = "secondObject",
                Previous = firstList,
                Random = firstList
            };
            firstList.Next = secondList;

            // Third List
            var thirdList = new ListNode
            {
                Data = "thirdObject",
                Previous = secondList,
                Random = firstList
            };
            secondList.Next = thirdList;

            // Fourth List
            var fourthList = new ListNode
            {
                Data = "fourthObject",
                Previous = thirdList,
                Random = secondList
            };
            thirdList.Next = fourthList;

            // Random
            ListRandom randomList = new ListRandom
            {
                Count = 4,
                Head = firstList,
                Tail = fourthList
            };

            // Serialize
            using (FileStream fileStream = new FileStream("DATA.dat",
                    FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                randomList.Serialize(fileStream);
            }

            // Deserialize
            var resource = new ListRandom();
            using (FileStream fileStream = new FileStream("DATA.dat",
                    FileMode.Open, FileAccess.Read, FileShare.None))
            {
                resource.Deserialize(fileStream);
            }
        }
    }
}
