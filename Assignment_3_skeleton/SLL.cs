

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_3_skeleton
{
    public class SLL : LinkedListADT
    {
		//two fields
		Node head;
		Node tail;

		//constructor
		public SLL()
		{
			Head = Tail = null;
		}
		//getter and setter
		public Node Head { get => head; set => head = value; }
		public Node Tail { get => tail; set => tail = value; }

        //Adds to the end of the list.
        public void Append(object data)
        {
			if (!IsEmpty())
			{
				tail.Successor = new Node(data);
				tail = tail.Successor;
			}
			else
			{
				head = tail = new Node(data);
			}
		}
		//clear all the nodes inside
        public void Clear()
        {
            head = null; 
        }
        //Go through list and check if we have this object
        public bool Contains(object data)
        {
			Node tempNode = head;
			while (tempNode != null)
			{
				if (tempNode.Element.Equals(data))
				{
					return true;
				}
				tempNode = tempNode.Successor;
			}
			return false;
		}
        //Removes element at index from list
        public void Delete(int index)
        {
            Node temp = head;
            int x = 0;
            do
            {
                if (index == 0)
                {
                    head = head.Successor;
                    break;
                }
                else if (x == index - 1 && temp.Successor != null)
                {
                    temp.Successor = temp.Successor.Successor;
                    break;
                }
                else
                {
					temp = temp.Successor;
				}
                x++;
            } while (x < index && temp != null); 
        }
        //Gets the first index of element containing this data
        public int IndexOf(object data)
        {
			int index = 0;
			Node tempNode = head;

			while (tempNode != null)
			{
				if (tempNode.Element.Equals(data))
				{
					return index;
				}
				index++;
				tempNode = tempNode.Successor;
			}

			return -1;
		}
        //Adds a new element at a specific position
        public void Insert(object data, int index)
        {
			Node preNode = head;
			Node newNode = new Node(data);
			if (index == 0)
			{
				newNode.Successor = head;
				head = newNode;
			}
			else
			{
				for (int i = 0; i < index - 1; i++)
				{
					preNode = preNode.Successor;
				}
				Node aftNode = preNode.Successor;
				newNode.Successor = aftNode;
				preNode.Successor = newNode;
			}
		}
        //Checks if the list is empty
        public bool IsEmpty()
        {
			if (head == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        //Prepends (adds to beginning) data to the list
        public void Prepend(object data)
        {
			head = new Node(data, head);
			if (tail == null) tail = head;
		}
        //Replaces the data  at index
        public void Replace(object data, int index)
        {
			Node tempNode = head;
			int count = 0;
			while (tempNode != null)
			{
				if (count == index)
				{
					tempNode.Element = data;
				}
				count++;
				tempNode = tempNode.Successor;
			}
		}
        //Gets the data at the specified index
        public object Retrieve(int index)
        {
            int x = 0;
            Node temp = head;
            while (x < index)
            {
                temp = temp.Successor;
                x++;
            }
            return temp.Element;
        }
        //Gets the number of elements in the list
        public int Size()
        {
			int size = 0;
			Node current = head;
			while (current != null)
			{
				size++;
				current = current.Successor;
			}
			return size;
		}
    }
}
