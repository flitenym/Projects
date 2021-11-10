using System.Text.Json;

namespace CrudNode
{
    public static class Sample
    {
        public static string XmlExample => @"{""id"":""1"",""name"": ""parent"",""children"":[{""id"":""1-1"",""name"":""child-1"",""children"":[{""id"":""1-1-1"",""name"":""child-1-1""}]},{""id"":""1-2"",""name"":""child-2"",""children"":[{""id"":""1-2-1"",""name"":""child-1-2""}]}]}";
    }
}