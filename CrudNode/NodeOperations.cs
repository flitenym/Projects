using System.Linq;

namespace CrudNode
{
    public static class NodeOperations
    {
        public static (bool IsSuccess, Node Node) SelectById(Node node, string id)
        {
            if (node.id == id)
            {
                return (true, node);
            }
            else
            {
                if (node.children == null)
                {
                    return (false, null);
                }

                foreach (var children in node.children)
                {
                    (bool isFounded, Node foundedNode) = SelectById(children, id);
                    if (isFounded)
                    {
                        return (isFounded, foundedNode);
                    }
                }
            }

            return (false, null);
        }

        public static (bool IsSuccess, Node ChildNode, Node ParentNode) SelectParentById(Node node, string id)
        {
            if (node.id == id)
            {
                return (true, node, null);
            }
            else
            {
                if (node.children == null)
                {
                    return default;
                }

                foreach (var children in node.children)
                {
                    (bool isFounded, Node foundedNode, Node parentNode) = SelectParentById(children, id);
                    if (isFounded)
                    {
                        return (isFounded, foundedNode, node);
                    }
                }
            }

            return default;
        }

        public static bool Update(Node node, string id, string name)
        {
            (bool isSuccessSelect, Node selectedNode) = SelectById(node, id);
            if (isSuccessSelect && selectedNode != null)
            {
                selectedNode.name = name;
                return true;
            }
            return false;
        }

        public static bool Insert(Node node, string id, Node newNode)
        {
            (bool isSuccessSelect, Node selectedNode) = SelectById(node, id);
            if (isSuccessSelect && selectedNode != null)
            {
                if (selectedNode.children == null)
                {
                    selectedNode.children = new Node[] { };
                }
                selectedNode.children = selectedNode.children.Concat(new Node[] { newNode }).ToArray();
                return true;
            }
            return false;
        }

        public static bool Delete(Node node, string id)
        {
            (bool isSuccessSelect, Node selectedNode, Node parentNode) = SelectParentById(node, id);
            if (isSuccessSelect && parentNode != null)
            {
                parentNode.children = parentNode.children.Except(new Node[] { selectedNode }).ToArray();
                return true;
            }
            return false;
        }
    }
}
