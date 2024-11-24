using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.Utility
{
    [DataContract]
    [KnownType(typeof(Node))]
    [KnownType(typeof(User))]
    public class SLL : ILinkedListADT
    {
        [DataMember] private Node head;
        [DataMember] private int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value)
            {
                Next = head
            };
            head = newNode;
            size++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            size++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        public int Count()
        {
            return size;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty.");
            }
            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            size--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            size--;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            for (int i = 0; i < size; i++)
            {
                if (current.Value.Equals(value))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }


        public void Reverse()
        {
            if (IsEmpty() || head.Next == null)
            {
                return;
            }

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }


        public void Serialize(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialization failed: {ex.Message}");
            }
        }
        public static SLL Deserialize(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (SLL)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization failed: {ex.Message}");
                return null;
            }
        }
    }
}
