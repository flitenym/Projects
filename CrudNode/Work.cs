using System;

namespace CrudNode
{
    public static class Work
    {
        public static void DoWork()
        {
            Node node = Node.Parse(Sample.XmlExample);

            var foundedNode = NodeOperations.SelectById(node, "1-2-1");
            var isUpdatedNode = NodeOperations.Update(node, "1-2-1", "Обновился у");
            var isInsertedNode = NodeOperations.Insert(node, "1-2-1", new Node() { id = "IDDD", name = "YA TCAR" });
            var isDeletedNode = NodeOperations.Delete(node, "1-2");
        }
    }
}
