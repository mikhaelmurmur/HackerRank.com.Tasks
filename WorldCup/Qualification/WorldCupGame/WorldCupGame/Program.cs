using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Solution
{
    public class Node
    {
        public List<Node> nodes = new List<Node>();
        long? sum = null;
        long? max = null;
        public long? ReturnSum()
        {
            return sum;
        }

        public void PushSum(long? _sum)
        {
            if (sum != null)
            {
                sum += _sum;
            }
            else
            {
                sum = _sum;
            }
            if (max != null)
            {
                if (max < _sum)
                {
                    max = _sum;
                }
            }
            else
            {
                max = _sum;
            }
        }

        public long? GetRealMax()
        {
            return sum - max;
        }


    }


    static void SetAllSums(Node startNode, Node previousNode)
    {
        if ((startNode.nodes.Count > 1)||previousNode==null)
        {
            foreach (Node node in startNode.nodes)
            {
                if (node != previousNode)
                {
                    SetAllSums(node, startNode);
                    startNode.PushSum(node.ReturnSum());
                }
            }
        }
    }

    static void SetAllSumsWithTheChoosenOne(Node startNode, Node previousNode)
    {
        if ((startNode.nodes.Count > 1) || previousNode == null)
        {
            foreach (Node node in startNode.nodes)
            {
                if (node != previousNode)
                {
                    node.PushSum(startNode.ReturnSum() - node.ReturnSum());
                    SetAllSumsWithTheChoosenOne(node, startNode);
                }
            }
        }
    }



    static void Main(string[] args)
    {
        int nodesNumber = int.Parse(Console.ReadLine());
        List<Node> nodes = new List<Node>();
        int[] tokens = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        for (int nodeIndex = 0; nodeIndex < tokens.Length; nodeIndex++)
        {
            nodes.Add(new Node());
            nodes[nodeIndex].PushSum(tokens[nodeIndex]);

        }

        for (int i = 0; i < nodesNumber - 1; i++)
        {
            int[] nodesPair = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            nodes[nodesPair[0] - 1].nodes.Add(nodes[nodesPair[1] - 1]);
            nodes[nodesPair[1] - 1].nodes.Add(nodes[nodesPair[0] - 1]);

        }
        SetAllSums(nodes[0], null);
        SetAllSumsWithTheChoosenOne(nodes[0], null);

        long? max = nodes[0].GetRealMax();

        foreach(Node node in nodes)
        {
            if(max<node.GetRealMax())
            {
                max = node.GetRealMax();
            }
        }
        Console.WriteLine(max);
    }
}

