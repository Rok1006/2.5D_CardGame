using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public int numberOfSpheres = 10;
    public float curveHeight = 5.0f;
    public GameObject prefab;
    private bool showSphere = false;
    private List<GameObject> spheres = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i <= numberOfSpheres; i++)
        {
            float t = i / (float)numberOfSpheres;
            Vector3 position = CalculateBezierPoint(t, startPoint.position, endPoint.position, curveHeight);
            GameObject sphere = InstantiateSphere(position);
            sphere.GetComponent<SphereCollider>().enabled = false;
            spheres.Add(sphere);
            sphere.SetActive(false);
        }
    }
    public void InitializeSphere()
    {
        foreach(GameObject go in spheres)
        {
            go.SetActive(true);
            showSphere = true;
        }
    }
    public void HideSphere()
    {
        foreach (GameObject go in spheres)
        {
            go.SetActive(false);
            showSphere = false;
        }
    }

    private GameObject InstantiateSphere(Vector3 position)
    {
        GameObject sphere = Instantiate(prefab);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphere.transform.position = position;
        
        return sphere;
    }

    private void Update()
    {
        if(showSphere)
        {

          UpdateSpheresPosition();
        }
    }

    private void UpdateSpheresPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = hit.point;

            for (int i = 0; i < spheres.Count; i++)
            {
                float t = i / (float)numberOfSpheres;
                Vector3 position = CalculateBezierPoint(t, startPoint.position, mousePosition, curveHeight);
                spheres[i].transform.position = position;
            }
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
}
