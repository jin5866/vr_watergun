using UnityEngine;
using UnityEditor;
using com.zibra.liquid.SDFObjects;
using com.zibra.liquid.Manipulators;

namespace com.zibra.liquid.Editor.Solver
{
    [CustomEditor(typeof(ZibraLiquidForceField))]
    [CanEditMultipleObjects]
    public class ZibraLiquidForceFieldEditor : ZibraLiquidManipulatorEditor
    {
        private ZibraLiquidForceField[] ForceFieldInstances;

        private SerializedProperty Type;
        private SerializedProperty Strength;
        private SerializedProperty DistanceDecay;
        private SerializedProperty DistanceOffset;
        private SerializedProperty DisableForceInside;
        private SerializedProperty ForceDirection;
        public override void OnInspectorGUI()
        {
            bool missingSDF = false;
            bool hasNeuralSDF = false;

            foreach (var instance in ForceFieldInstances)
            {
                SDFObject sdf = instance.GetComponent<SDFObject>();
                if (sdf == null)
                {
                    missingSDF = true;
                    continue;
                }

                if (sdf is NeuralSDF)
                {
                    hasNeuralSDF = true;
                    continue;
                }
            }

            if (missingSDF)
            {
                if (ForceFieldInstances.Length > 1)
                    EditorGUILayout.HelpBox("At least 1 force field missing shape. Please add Zibra SDF.",
                                            MessageType.Error);
                else
                    EditorGUILayout.HelpBox("Missing force field shape. Please add Zibra SDF.", MessageType.Error);
                if (GUILayout.Button(ForceFieldInstances.Length > 1 ? "Add Analytic SDFs" : "Add Analytic SDF"))
                {
                    foreach (var instance in ForceFieldInstances)
                    {
                        if (instance.GetComponent<SDFObject>() == null)
                        {
                            Undo.AddComponent<AnalyticSDF>(instance.gameObject);
                        }
                    }
                }
                GUILayout.Space(5);
            }

            if (hasNeuralSDF)
            {
                if (ForceFieldInstances.Length > 1)
                    EditorGUILayout.HelpBox(
                        "At least 1 emitter has Neural SDF. Neural SDFs on Emitters are not supported in this version.",
                        MessageType.Error);
                else
                    EditorGUILayout.HelpBox("Neural SDFs on Emitters are not supported in this version",
                                            MessageType.Error);
                GUILayout.Space(5);
            }

            serializedObject.Update();

            EditorGUILayout.PropertyField(Type);
            EditorGUILayout.PropertyField(Strength);
            EditorGUILayout.PropertyField(DistanceDecay);
            EditorGUILayout.PropertyField(DistanceOffset);
            EditorGUILayout.PropertyField(DisableForceInside);
            EditorGUILayout.PropertyField(ForceDirection);

            serializedObject.ApplyModifiedProperties();
        }

        // clang-format doesn't parse code with new keyword properly
        // clang-format off

        protected new void OnEnable()
        {
            base.OnEnable();

            ForceFieldInstances = new ZibraLiquidForceField[targets.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                ForceFieldInstances[i] = targets[i] as ZibraLiquidForceField;
            }

            Type = serializedObject.FindProperty("Type");
            Strength = serializedObject.FindProperty("Strength");
            DistanceDecay = serializedObject.FindProperty("DistanceDecay");
            DistanceOffset = serializedObject.FindProperty("DistanceOffset");
            DisableForceInside = serializedObject.FindProperty("DisableForceInside");
            ForceDirection = serializedObject.FindProperty("ForceDirection");
        }
    }
}