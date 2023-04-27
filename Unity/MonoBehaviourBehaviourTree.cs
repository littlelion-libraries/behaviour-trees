using Newtonsoft.Json;
using UnityEngine;

namespace BehaviourTrees.Unity
{
    public class MonoBehaviourBehaviourTree : MonoBehaviour
    {
        [SerializeField] private string text;
        [SerializeField] private bool textAsset;
        private IBTNode _node;
        public IBTNode Node => _node;

        private void Awake()
        {
            var node = JsonConvert.DeserializeObject<JsonBehaviourTreeNode>(text);
            _node = Application.isEditor ? TickBtNodeUtils.Create(node) : BehaviourTreeUtils.Create(node);
        }

        public bool Step()
        {
            return !gameObject || !_node.Step();
        }
    }
}