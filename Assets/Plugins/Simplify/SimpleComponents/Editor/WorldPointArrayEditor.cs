using Simplify.SimpleComponents;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Plugins.Simplify.SimpleComponents
{
    [CustomEditor(typeof(WorldPointArrayComponent))]
    internal class WorldPointArrayEditor : Editor
    {
        private bool edit;
        private static GUISkin guiSkin;

        public static GUISkin GUISkin
        {
            get
            {
                if (guiSkin == null)
                    guiSkin = Resources.Load<GUISkin>("NumberLabels");
                return guiSkin;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
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
            var worldPoints = target as WorldPointArrayComponent;
            for (var i = 0; i < worldPoints.Length; i++)
            {
                DrawHandle(worldPoints[i], i);
            }
        }

        private void DrawHandle(IWorldPoint worldPointComponent, int i)
        {
            switch (ToolManager.activeToolType.Name)
            {
                case "MoveTool":
                    DrawPositionHandle(worldPointComponent, i);
                    break;
                
                case "RotateTool":
                    DrawRotateHandle(worldPointComponent, i);
                    break;

                case "TransformTool":
                {
                    DrawPositionHandle(worldPointComponent, i);
                    DrawRotateHandle(worldPointComponent, i);
                    break;
                }
            }
        }

        private void DrawPositionHandle(IWorldPoint worldPointComponent, int i)
        {
            EditorGUI.BeginChangeCheck();
            var rot = Tools.pivotRotation == PivotRotation.Global ? Quaternion.identity : worldPointComponent.Rotation;
            Handles.Label(worldPointComponent.Position, i.ToString(), GUISkin.label);
            var newTargetPosition = Handles.PositionHandle(worldPointComponent.Position, rot);
            Handles.Label(newTargetPosition, i.ToString());
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Changed Position");
                worldPointComponent.Position = newTargetPosition;
            }
        }
        
        private void DrawRotateHandle(IWorldPoint worldPointComponent, int i)
        {
            EditorGUI.BeginChangeCheck();
            var newTargetRotation = Handles.RotationHandle(worldPointComponent.Rotation, worldPointComponent.Position);
            Handles.Label(worldPointComponent.Position, i.ToString(), GUISkin.label);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Changed Rotation");
                worldPointComponent.Rotation = newTargetRotation;
            }
        }
    }
}