namespace DTO
{
    public enum NodeType
    {
        Root,
        Node,
        SubTree
    }

    public class Node
    {
        public string Name;
        public int? TestValue;
        public NodeType Type;
        public Node RightNode;
        public Node LeftNode;

        public Node(string name, NodeType node)
        {
            Name = name;
            Type = node;
        }
    }
}
