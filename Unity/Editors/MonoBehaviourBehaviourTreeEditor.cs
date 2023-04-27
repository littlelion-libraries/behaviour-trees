using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace BehaviourTrees.Unity.Editors
{
    [CustomEditor(typeof(MonoBehaviourBehaviourTree))]
    public class MonoBehaviourBehaviourTreeEditor : Editor
    {
        private readonly BehaviourTreeNodeDrawer _drawer = new();

        private static void DrawNode(TickBTNode node, int tick)
        {
            var foldoutStyle = new GUIStyle(EditorStyles.foldout);
            if (node.Tick >= tick)
            {
                foldoutStyle.normal.textColor = Color.green;
            }

            var type = node.Impl.GetType();
            node.Expanded = EditorGUILayout.Foldout(node.Expanded, type.Name, foldoutStyle);
            switch (node.Impl)
            {
                case RepeatBTNode repeatBtNode:
                    EditorGUI.indentLevel++;
                    DrawNode((TickBTNode)repeatBtNode.Impl, tick);
                    EditorGUI.indentLevel--;
                    break;
                case SequenceBTNode sequenceBtNode:
                {
                    EditorGUI.indentLevel++;
                    foreach (var it in sequenceBtNode.Nodes)
                    {
                        DrawNode((TickBTNode)it, tick);
                    }

                    EditorGUI.indentLevel--;
                    break;
                }
                case ParallelBTNode parallelBtNode:
                {
                    EditorGUI.indentLevel++;
                    foreach (var it in parallelBtNode.Nodes)
                    {
                        DrawNode((TickBTNode)it, tick);
                    }

                    EditorGUI.indentLevel--;
                    break;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            if (Application.isPlaying)
            {
                var node = ((MonoBehaviourBehaviourTree)target).Node;
                if (node == null) return;
                var tickNode = (TickBTNode)node;
                DrawNode(tickNode, tickNode.Tick);
                return;
            }

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
            var textProp = serializedObject.FindProperty("text");
            var textAssetProp = serializedObject.FindProperty("textAsset");
            EditorGUILayout.PropertyField(textAssetProp);
            var textAsset = textAssetProp.boolValue
                ? AssetDatabase.LoadAssetAtPath<TextAsset>(AssetDatabase.GUIDToAssetPath(textProp.stringValue))
                : null;
            if (textAssetProp.boolValue)
            {
                textAsset = EditorGUILayout.ObjectField("Asset", textAsset, typeof(TextAsset), false) as TextAsset;
                textProp.stringValue =
                    AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(textAsset)).ToString();
            }

            var text = textAssetProp.boolValue
                ? textAsset == null ? string.Empty : textAsset.text
                : textProp.stringValue;
            if (!textAssetProp.boolValue || textAsset != null)
            {
                text = JsonConvert.SerializeObject(
                    _drawer.DrawNode(
                        JsonConvert.DeserializeObject<JsonBehaviourTreeNode>(text) ??
                        new JsonBehaviourTreeNode(),
                        "Root"
                    ),
                    Formatting.Indented
                );
            }

            if (textAssetProp.boolValue)
            {
                if (GUI.changed)
                {
                    if (textAsset != null)
                    {
                        File.WriteAllText(AssetDatabase.GetAssetPath(textAsset), text);
                        AssetDatabase.Refresh();
                    }
                }
            }
            else
            {
                textProp.stringValue = text;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}