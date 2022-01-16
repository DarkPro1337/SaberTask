using System;
using System.Collections.Generic;
using System.IO;

namespace ListNodeTask
{
    class ListNode
    {
        /// <summary>
        /// Sequence element that is previous to the current one.
        /// </summary>
        public ListNode Previous;
        /// <summary>
        /// Sequence element that is next to the current one.
        /// </summary>
        public ListNode Next;
        /// <summary>
        /// Referencing an random element inside a list 
        /// </summary>
        public ListNode Random;
        public string Data;
    }

    class ListRandom
    {
        /// <summary>
        /// Node at the start of a list.
        /// </summary>
        public ListNode Head;
        /// <summary>
        /// Node at the end of a list.
        /// </summary>
        public ListNode Tail;
        /// <summary>
        /// Nodes count in a list.
        /// </summary>
        public int Count;

        /// <summary>
        /// Serializes the current object.
        /// </summary>
        /// <param name="s">Filestream to which the serialized object will be written.</param>
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

        /// <summary>
        /// Deserializes from a file, overwriting the data of the current object.
        /// </summary>
        /// <param name="s">Filestream from which the serialized object will be read.</param>
        public void Deserialize(Stream s)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(s))
                {
                    Count = br.ReadInt32();

                    var nodeList = new List<ListNode>(Count);

                    for (int i = 0; i < Count; i++)
                    {
                        nodeList.Add(new ListNode());
                    }

                    for (int i = 0; i < Count; i++)
                    {
                        nodeList[i].Previous = i > 0 ? nodeList[i - 1] : null;
                        nodeList[i].Next = i < (Count - 1) ? nodeList[i + 1] : null;
                        nodeList[i].Data = br.ReadString();

                        int randIdx = br.ReadInt32();

                        nodeList[i].Random = randIdx >= 0 ? nodeList[randIdx] : null;
                    }

                    Head = nodeList[0];
                    Tail = nodeList[Count - 1];
                }
            }
            catch (Exception ex) when (ex is ObjectDisposedException ||
                                       ex is EndOfStreamException ||
                                       ex is IOException)
            {
                Count = 0;
                Head  = null;
                Tail  = null;
            }
        }
    }
}
