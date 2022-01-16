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

        }

        public void Deserialize(Stream s)
        {

        }
    }
}
