using System;
using Simplify.SimpleComponents;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Plugins.Simplify.SimpleComponents
{
    [CustomEditor(typeof(WorldPointComponent))]
    internal class WorldPointEditor : Editor
    {
        private bool edit;
        private PivotRotation pivotRotation;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var label = edit ? "Stop Edit" : "Edit";
            if (GUILayout.Button(label))
            {
                edit = !edit;
            }
        }

        private void OnSceneGUI()
        {
            if (!edit)
                return;
            pivotRotation = Tools.pivotRotation;
            var worldPoint = target as WorldPointComponent;
            DrawHandle(worldPoint);
        }
        
        private void DrawHandle(WorldPointComponent worldPointComponent)
        {
            switch (ToolManager.activeToolType.Name)
            {
                case "MoveTool":
                    DrawPositionHandle(worldPointComponent);
                    break;
                
                case "RotateTool":
                    DrawRotateHandle(worldPointComponent);
                    break;

                case "TransformTool":
                {
                    DrawPositionHandle(worldPointComponent);
                    DrawRotateHandle(worldPointComponent);
                    break;
                }
            }
        }

        private void DrawPositionHandle(WorldPointComponent worldPointComponent)
        {
            EditorGUI.BeginChangeCheck();
            var rot = pivotRotation == PivotRotation.Global ? Quaternion.identity : worldPointComponent.Rotation;
            var newTargetPosition = Handles.PositionHandle(worldPointComponent.Position, rot);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(worldPointComponent, "Changed Target Position");
                worldPointComponent.Position = newTargetPosition;
                EditorUtility.SetDirty(worldPointComponent);
            }
        }
        
        private void DrawRotateHandle(WorldPointComponent worldPointComponent)
        {
            EditorGUI.BeginChangeCheck();
            var newTargetRotation = Handles.RotationHandle(worldPointComponent.Rotation, worldPointComponent.Position);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(worldPointComponent, "Changed Target Rotation");
                worldPointComponent.Rotation = newTargetRotation;
                EditorUtility.SetDirty(worldPointComponent);
            }
        }
    }
}