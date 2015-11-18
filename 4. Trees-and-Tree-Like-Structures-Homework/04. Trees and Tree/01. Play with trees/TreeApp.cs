namespace _01.Play_with_trees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeApp
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        static Stack<List<Tree<int>>> allPaths = new Stack<List<Tree<int>>>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Root node: {0}", FindRootNode().Value);
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", FindMiddleNodes().Select(n => n.Value).ToList()));
            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", FindLeafs().Select(n => n.Value).ToList()));
            FindAllPaths();
            var longestPath = allPaths
                .ToList()
                .Select(l => new { Length = l.Count, Nodes = string.Join(" -> ", l.Select(v => v.Value).ToList()) })
                .OrderByDescending(p => p.Length)
                .FirstOrDefault();
            Console.WriteLine("Longest path: {0} (length = {1})", longestPath.Nodes, longestPath.Length);

            var pathsOfSum = allPaths
                .ToList()
                .Select(l => new { Sum = l.Sum(t => t.Value), Nodes = string.Join(" -> ", l.Select(v => v.Value).ToList()) })
                .Where(p => p.Sum == pathSum)
                .ToList();
            Console.WriteLine("Paths with sum of {0}:", pathSum);
            if (pathsOfSum.Count == 0)
            {
                Console.WriteLine("No paths found.");
            }
            else
            {
                foreach (var path in pathsOfSum)
                {
                    Console.WriteLine(path.Nodes);
                }
            }

            Console.WriteLine("Here are all paths in the tree:");
            allPaths.ToList()
                .Select(l => new { Sum = l.Sum(t => t.Value), Nodes = string.Join(" -> ", l.Select(v => v.Value).ToList()) })
                .ToList()
                .ForEach(p => Console.WriteLine(p.Nodes));
        }

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(v => v.Parent == null);
            return rootNode;
        }

        public static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(v => v.Children.Count > 0 && v.Parent != null)
                .OrderBy(v => v.Value)
                .ToList();
            return middleNodes;
        }

        public static IEnumerable<Tree<int>> FindLeafs()
        {
            var leafNodes = nodeByValue.Values
                .Where(v => v.Children.Count == 0)
                .OrderBy(v => v.Value)
                .ToList();
            return leafNodes;
        }

        public static void FindAllPaths()
        {
            List<Tree<int>> firstPath = new List<Tree<int>>();
            firstPath.Add(FindRootNode());
            allPaths.Push(firstPath);
            FindPath(FindRootNode(), firstPath);
        }

        public static void FindPath(Tree<int> currentNode, List<Tree<int>> currentPath) {
            if (currentNode.Children.Count == 0)
            {
                allPaths.Push(currentPath);
                return;
            }
            else
            {
                foreach (var child in currentNode.Children)
                {
                    Tree<int>[] newPathArray = new Tree<int>[currentPath.Count];
                    currentPath.CopyTo(newPathArray);
                    List<Tree<int>> newPath = newPathArray.ToList();
                    newPath.Add(child);
                    FindPath(child, newPath);
                }
            }
        }
    }
}
