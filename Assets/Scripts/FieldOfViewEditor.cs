using UnityEngine;
using UnityEditor;

// Ensure this namespace matches the namespace of the FieldOfView class if it's defined in one.
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, fow.transform.forward, 360, fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);       
    
        Handles.color += Color.red;
        foreach (Transform visibleTarget in fow.visiableTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}


// Reference -> https://www.youtube.com/watch?v=rQG9aUWarwE