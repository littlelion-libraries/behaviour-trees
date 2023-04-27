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
            _node = BehaviourTreeUtils.Create(JsonConvert.DeserializeObject<JsonBehaviourTreeNode>(text));
            if (Application.isEditor)
            {
                _node = TickBtNodeUtils.Add(_node);
            }
        }

        public bool Step()
        {
            return !gameObject || !_node.Step();
        }
    }
}