using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour
{
    [SerializeField] TMP_InputField functionInput;
    [SerializeField] Button submitButton;
    [SerializeField] LineRenderer lineRenderer;

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmitFunction);
    }

    private void OnSubmitFunction()
    {
        string function = functionInput.text;

        List<Vector3> graphPoints = GenerateGraphPoints(function);

        DrawGraph(graphPoints);
    }

    public List<Vector3> GenerateGraphPoints(string function)
    {
        List<Vector3> points = new List<Vector3>();

        for (float x = -10f; x <= 10f; x += 0.1f)
        {
            float y = EvaluateFunction(function, x);
            points.Add(new Vector3(x, y, 0));
        }

        return points;
    }

    private float EvaluateFunction(string function, float x)
    {
        try
        {

            function = function.Replace("x", x.ToString());

            function = function.Replace("--", "+");

            var result = new System.Data.DataTable().Compute(function, "");

            return Convert.ToSingle(result);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error evaluating function '{function}' at x={x}: {e.Message}");
            return 0f;
        }
    }

    private void DrawGraph(List<Vector3> points)
    {
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}