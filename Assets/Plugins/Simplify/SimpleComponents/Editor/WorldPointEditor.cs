using Simplify.SimpleComponents;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Plugins.Simplify.SimpleComponents
{
    [CustomEditor(typeof(WorldPoint))]
    public class WorldPointEditor : Editor
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
            var worldPoint = target as WorldPoint;
            DrawHandle(worldPoint);
        }
        
        private void DrawHandle(WorldPoint relativeWorldPoint)
        {
            switch (ToolManager.activeToolType.Name)
            {
                case "MoveTool":
                    DrawPositionHandle(relativeWorldPoint);
                    break;
                
                case "RotateTool":
                    DrawRotateHandle(relativeWorldPoint);
                    break;

                case "TransformTool":
                {
                    DrawPositionHandle(relativeWorldPoint);
                    DrawRotateHandle(relativeWorldPoint);
                    break;
                }
                
                default: 
                    DrawPositionHandle(relativeWorldPoint);
                    break;
            }
        }

        private void DrawPositionHandle(WorldPoint relativeWorldPoint)
        {
            var rotation = relativeWorldPoint.Rotation.eulerAngles + relativeWorldPoint.transform.rotation.eulerAngles;
            var rot = pivotRotation == PivotRotation.Global ? Quaternion.identity : Quaternion.Euler(rotation);
            EditorGUI.BeginChangeCheck();
            var newTargetPosition = Handles.PositionHandle(relativeWorldPoint.transform.position + relativeWorldPoint.Position, rot);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(relativeWorldPoint, "Changed Target Position");
                relativeWorldPoint.Position = newTargetPosition - relativeWorldPoint.transform.position;
                EditorUtility.SetDirty(relativeWorldPoint);
            }
        }
        
        private void DrawRotateHandle(WorldPoint relativeWorldPoint)
        {
            EditorGUI.BeginChangeCheck();
            var rotation = relativeWorldPoint.Rotation.eulerAngles + relativeWorldPoint.transform.rotation.eulerAngles;
            var newTargetRotation = Handles.RotationHandle(Quaternion.Euler(rotation), 
                relativeWorldPoint.transform.position + relativeWorldPoint.Position);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(relativeWorldPoint, "Changed Target Rotation");
                relativeWorldPoint.rotationEuler = newTargetRotation.eulerAngles - relativeWorldPoint.transform.rotation.eulerAngles;
                EditorUtility.SetDirty(relativeWorldPoint);
            }
        }
    }
}