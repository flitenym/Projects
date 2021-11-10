using System;
using System.Text.Json;

namespace CrudNode
{
    [Serializable]
    public class Node
    {
        public string id { get; set; }
        public string name { get; set; }
        public Node[] children { get; set; }
        public static Node Parse(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<Node>(json);
        }
    }
}
