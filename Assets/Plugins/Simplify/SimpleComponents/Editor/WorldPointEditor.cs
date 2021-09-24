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

        public override void OnInspectorGUI()
        {
            var worldPointComponent = target as WorldPointComponent;
            var newPosition = EditorGUILayout.Vector3Field("Position", worldPointComponent.LocalPosition);
            if (newPosition != worldPointComponent.LocalPosition)
            {
                Undo.RecordObject(worldPointComponent, "Changed Position");
                worldPointComponent.LocalPosition = newPosition;
                SceneView.RepaintAll();
            }
            var newRotation = EditorGUILayout.Vector3Field("Rotation", worldPointComponent.LocalEulerRotation);
            if (newRotation != worldPointComponent.LocalEulerRotation)
            {
                Undo.RecordObject(worldPointComponent, "Changed Rotation");
                worldPointComponent.LocalEulerRotation = newRotation;
                SceneView.RepaintAll();
            }
            var label = edit ? "Stop Edit" : "Edit";
            if (GUILayout.Button(label))
            {
                edit = !edit;
                SceneView.RepaintAll();
            }
        }

        private void OnSceneGUI()
        {
            if (!edit)
                return;
            var worldPoint = target as WorldPointComponent;
            DrawHandle(worldPoint);
        }

        private static void DrawHandle(WorldPointComponent worldPointComponent)
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

        private static void DrawPositionHandle(WorldPointComponent worldPointComponent)
        {
            EditorGUI.BeginChangeCheck();
            var rot = Tools.pivotRotation == PivotRotation.Global ? Quaternion.identity : worldPointComponent.Rotation;
            var newTargetPosition = Handles.PositionHandle(worldPointComponent.Position, rot);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(worldPointComponent, "Changed Position");
                worldPointComponent.Position = newTargetPosition;
            }
        }
        
        private static void DrawRotateHandle(WorldPointComponent worldPointComponent)
        {
            EditorGUI.BeginChangeCheck();
            var newTargetRotation = Handles.RotationHandle(worldPointComponent.Rotation, worldPointComponent.Position);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(worldPointComponent, "Changed Rotation");
                worldPointComponent.Rotation = newTargetRotation;
            }
        }
    }
}