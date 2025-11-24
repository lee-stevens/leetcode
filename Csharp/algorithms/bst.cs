public class Node
{
  required int Value;
  List<Node> Children;
}

public class BinarySearchTree
{
  List<Node> Nodes = [];
  readonly int NodesPerDepth = 5;
  readonly int MaxDepth = 3;

  constructor()
  {
    Nodes = CreateTree();
  }

  private static List<Node> CreateTree()
  {
    for (int i = 0; i <= NodesPerDepth; i++)
    {
      Node node = new()
      {
        value = i,
        children = []
      };
    }
  }

  private static void AppendChildren(Node node, int childValue)
  {
    node.children.add(new Node()
    {
      value = childValue,
      children = []
    });
  }
}