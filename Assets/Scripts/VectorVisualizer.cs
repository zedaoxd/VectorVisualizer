using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum VectorOperation
{
    None = 0,
    Add = 1,
    Scale = 2,
    Normalize = 3,
}
public class VectorVisualizer : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private Text text;

    [Header("Values")] 
    [SerializeField] private MyVector3 v;
    [SerializeField] private MyVector3 w;
    [SerializeField] private float k;
    [Space] [Space] [SerializeField] private VectorOperation _operation = VectorOperation.None;

    private const float VectorThickess = 5.0f;
    private const float AxisSize = 10.0f;

    private void OnDrawGizmos()
    {
        DrawAxis();
        text.text = "";
        
        switch (_operation)
        {
            case VectorOperation.None:
                DrawVectorWithGuideLines(v, VectorThickess);
                break;
            case VectorOperation.Add:
                DrawAdd();
                break;
            case VectorOperation.Scale:
                DrawScale();
                break;
            case VectorOperation.Normalize:
                DrawNormalize();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawScale()
    {
        var result = v * k;
        
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, VectorThickess);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, VectorThickess);
        text.text = $"Scaled Position: {result}\nScaled Magnitude: {result.Magnitude}";
    }

    private void DrawNormalize()
    {
        var result = v.Normalized;
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, VectorThickess);
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, VectorThickess);

        text.text = $"Normalized Vector: {result}\nNormalized Mganitude: {result.Magnitude}";
    }
    
    private void DrawAxis()
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(MyVector3.Right * AxisSize);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(MyVector3.Up * AxisSize);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVectorAtOrigin(MyVector3.Forward * AxisSize);
    }

    private void DrawVectorWithGuideLines(MyVector3 vector, float thickess)
    {
        var vx = new MyVector3(vector.X, 0, 0);
        var vy = new MyVector3(0, vector.Y, 0);
        var vz = new MyVector3(0, 0, vector.Z);
        
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(vector, thickess);
        Gizmos.color = Color.red;
        GizmosUtils.DrawVector(vx, vz, 1, false);
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(vz, vx, 1, false);
        Gizmos.color = Color.green;
        GizmosUtils.DrawVector(vx + vz, vy, 1, false);

        text.text = $"Magnitude: {vector.Magnitude}";
    }

    private void DrawAdd()
    {
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v, VectorThickess);
        Gizmos.color = Color.gray;
        GizmosUtils.DrawVector(v, w, VectorThickess);
        var result = v + w;
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(result, VectorThickess);

        text.text = $"Result: {result}";
    }
    
}
