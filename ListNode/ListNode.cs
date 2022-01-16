using System;
using System.Collections.Generic;
using System.IO;

namespace ListNode
{
    class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random; // произвольный элемент внутри списка
        public string Data;
    }

    class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
            var nodeList = new List<ListNode>();
            var currentNode = Head;

            while (currentNode != null)
            {
                nodeList.Add(currentNode);
                currentNode = currentNode.Next;
            }

            if (nodeList.Count != Count)
            {
                throw new Exception("Structure of ListRand object and Count aren't equal!");
            }

            using (BinaryWriter bw = new BinaryWriter(s))
            {
                bw.Write(Count);

                foreach (var node in nodeList)
                {
                    bw.Write(node.Data);
                    int position = -1;

                    if (node.Random != null)
                    {
                        position = nodeList.IndexOf(node.Random);
                    }

                    bw.Write(position);
                }
            }
        }

        public void Deserialize(Stream s)
        {

        }
    }
}
