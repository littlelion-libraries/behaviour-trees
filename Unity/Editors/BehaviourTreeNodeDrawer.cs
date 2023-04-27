using System;
using CSharpBoosts;
using UnityEditor;
using UnityEngine;

namespace BehaviourTrees.Unity.Editors
{
    public class BehaviourTreeNodeDrawer
    {
        private static bool DrawAddButton()
        {
            return GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Plus"));
        }

        public void DrawArrayNode(JsonBehaviourTreeNode node)
        {
            EditorGUI.indentLevel++;
            node.Args ??= Array.Empty<JsonBehaviourTreeNode>();
            EditorGUILayout.IntField("Size", node.Args.Length);
            for (var i = 0; i < node.Args.Length; i++)
            {
                node.Args[i] = DrawNode(node.Args[i], $"Element {i}");
            }

            EditorGUILayout.BeginHorizontal();
            if (DrawAddButton())
            {
                node.Args = ArrayUtils.Clone(node.Args, node.Args.Length + 1);
                node.Args[^1] = new JsonBehaviourTreeNode();
            }
            if (DrawRemoveButton())
            {
                node.Args = ArrayUtils.Clone(node.Args, node.Args.Length - 1);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;
        }

        public void DrawRepeatNode(JsonBehaviourTreeNode node)
        {
            if (node.Args == null || node.Args.Length < 1)
            {
                node.Args = new JsonBehaviourTreeNode[]
                {
                    new()
                };   
            }
            EditorGUI.indentLevel++;
            DrawNode(node.Args[0], "Child");
            EditorGUI.indentLevel--;
        }

        public JsonBehaviourTreeNode DrawNode(JsonBehaviourTreeNode node, string label)
        {
            EditorGUILayout.BeginHorizontal();
            node.Expanded = EditorGUILayout.Foldout(node.Expanded, label);
            var monoScript = EditorGUILayout.ObjectField(
                AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(node.Guid)),
                typeof(MonoScript),
                false
            ) as MonoScript;
            EditorGUILayout.EndHorizontal();
            if (monoScript)
            {
                var type = monoScript.GetClass() ?? CSharpScript.GetType(monoScript.text);
                if (typeof(IBTNode).IsAssignableFrom(type))
                {
                    node.Guid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(monoScript)).ToString();
                    node.TypeName = type.AssemblyQualifiedName;
                    if (node.Expanded)
                    {
                        if (type == typeof(RepeatBTNode))
                        {
                            DrawRepeatNode(node);
                        }
                        else if (type == typeof(ParallelBTNode) || type == typeof(SequenceBTNode))
                        {
                            DrawArrayNode(node);
                        }
                    }
                }
            }
            else
            {
                node.Args = null;
                node.Guid = string.Empty;
                node.TypeName = string.Empty;
            }

            return node;
        }

        private static bool DrawRemoveButton()
        {
            return GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Minus"));
        }
    }
}