using Newtonsoft.Json;

namespace BehaviourTrees
{
    public class JsonBehaviourTreeNode
    {
        [JsonProperty("args")] public JsonBehaviourTreeNode[] Args;
        [JsonProperty("expanded")] public bool Expanded;
        [JsonProperty("guid")] public string Guid;
        [JsonProperty("type-name")] public string TypeName;
    }
}