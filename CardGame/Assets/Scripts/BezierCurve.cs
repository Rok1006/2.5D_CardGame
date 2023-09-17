using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int numberOfSpheres = 10;
    public float curveHeight = 5.0f;

    private void Start()
    {
        for (int i = 0; i <= numberOfSpheres; i++)
        {
            float t = i / (float)numberOfSpheres;
            Vector3 position = CalculateBezierPoint(t, startPoint.position, endPoint.position, curveHeight);
            InstantiateSphere(position);
        }
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p2, float height)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * (p0 + Vector3.up * height);
        p += tt * p2;

        return p;
    }

    private void InstantiateSphere(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
    }
}
