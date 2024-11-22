using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
	public class Node
	{
		//field
		object element;
		Node successor;
		//setter and getter
		public object Element { get => element; set => element = value; }
		public Node Successor { get => successor; set => successor = value; }
		//constructor with one parameter
		public Node(object o)
		{
			Element = o;
		}
		//constructor with two parameters
		public Node(object o, Node n)
		{
			Element = o;
			Successor = n;
		}
	}
}
