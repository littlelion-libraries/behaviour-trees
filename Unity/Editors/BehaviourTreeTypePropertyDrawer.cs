using CSharpBoosts;
using UnityEditor;
using UnityEngine;

namespace BehaviourTrees.Unity.Editors
{
    [CustomPropertyDrawer(typeof(BehaviourTreeNode))]
    public class BehaviourTreeTypePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!property.isExpanded) return EditorGUIUtility.singleLineHeight;
            var argsProp = property.FindPropertyRelative("args");
            var guidProp = property.FindPropertyRelative("guid");
            var monoScript =
                AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guidProp.stringValue));
            if (monoScript == null) return EditorGUIUtility.singleLineHeight;
            var type = monoScript.GetClass() ?? CSharpScript.GetType(monoScript.text);
            if (type == typeof(RepeatBTNode))
            {
                return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing +
                       GetPropertyHeight(argsProp.GetArrayElementAtIndex(0), label);
            }

            if (type == typeof(ParallelBTNode) || type == typeof(SequenceBTNode))
            {
                var height = EditorGUIUtility.singleLineHeight * 2 + EditorGUIUtility.standardVerticalSpacing;
                if (argsProp.isExpanded)
                {
                    height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;// * 3;
                    for (var i = 0; i < argsProp.arraySize; i++)
                    {
                        var elementProp = argsProp.GetArrayElementAtIndex(i);
                        height += elementProp.isExpanded
                            ? GetPropertyHeight(argsProp.GetArrayElementAtIndex(i), label)
                            : EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                    }
                    return height + EditorGUIUtility.singleLineHeight;
                }
                return height;
            }

            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
            EditorGUI.BeginProperty(position, label, property);
            property.isExpanded = EditorGUI.Foldout(
                new Rect(
                    position.x,
                    position.y,
                    position.width,
                    EditorGUIUtility.singleLineHeight
                ),
                property.isExpanded,
                label
            );
            var labelPosition = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            var guidProp = property.FindPropertyRelative("guid");
            var typeNameProp = property.FindPropertyRelative("typeName");
            var argsProp = property.FindPropertyRelative("args");
            var monoScript = EditorGUI.ObjectField(
                new Rect(
                    labelPosition.x,
                    labelPosition.y,
                    labelPosition.width,
                    EditorGUIUtility.singleLineHeight
                ),
                AssetDatabase.LoadAssetAtPath<MonoScript>(AssetDatabase.GUIDToAssetPath(guidProp.stringValue)),
                typeof(MonoScript),
                false
            ) as MonoScript;
            if (property.isExpanded)
            {
                if (monoScript)
                {
                    var type = monoScript.GetClass() ?? CSharpScript.GetType(monoScript.text);
                    if (typeof(IBTNode).IsAssignableFrom(type))
                    {
                        guidProp.stringValue = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(monoScript))
                            .ToString();
                        typeNameProp.stringValue = type.AssemblyQualifiedName;
                        position.y += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                        if (type == typeof(RepeatBTNode))
                        {
                            argsProp.arraySize = 1;
                            EditorGUI.indentLevel++;
                            EditorGUI.PropertyField(position, argsProp.GetArrayElementAtIndex(0),
                                new GUIContent("Node"));
                            EditorGUI.indentLevel--;
                        }
                        else if (type == typeof(ParallelBTNode) || type == typeof(SequenceBTNode))
                        {
                            EditorGUI.indentLevel++;
                            EditorGUI.PropertyField(position, argsProp);
                            EditorGUI.indentLevel--;
                        }
                    }
                }
                else
                {
                    argsProp.arraySize = 0;
                    guidProp.stringValue = string.Empty;
                    typeNameProp.stringValue = string.Empty;
                }
            }

            EditorGUI.EndProperty();
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}