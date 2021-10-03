using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderer3D : MonoBehaviour
{
    public Transform globalParent;
    public List<Vector3> points = new List<Vector3>();
    public List<GameObject> renderedCapsules = new List<GameObject>();
    public GameObject capsulePrefab;
    public float radius;
    public GameObject spherePrefab;
    public Color color = new Color(1, 1, 1);
    public Material lineMaterial;

    // Start is called before the first frame update
    public void LineConstructor(Vector3 initialPoint,Color newColor, float rad)
    {
        color = newColor;
        radius = rad;

        points.Add(initialPoint);
        points.Add(initialPoint);
        renderLine();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void renderLine()
    {
        for(int i = 0; i < points.Count; i++)
        {
            if(i == 0)
            {
                GameObject initialCap = Instantiate(spherePrefab, points[i], Quaternion.identity);
                initialCap.transform.localScale = new Vector3(radius, radius, radius);
                initialCap.GetComponent<MeshRenderer>().material.color = color;
            }
            if (i == points.Count - 1);
            else
            {
                GameObject newCylinder = renderSegment(points[i], points[i + 1]);
                GameObject capstone = Instantiate(spherePrefab, points[i + 1], Quaternion.identity);
                capstone.transform.localScale = new Vector3(radius, radius, radius);
                
            }
        }
    }

    public void addPoint(Vector3 point)
    {
        points.Add(point);
        GameObject newCylinder = renderSegment(points[points.Count-2], points[points.Count-1]);
        GameObject capstone = Instantiate(spherePrefab, points[points.Count-1], Quaternion.identity);
        capstone.transform.localScale = new Vector3(radius, radius, radius);
        capstone.GetComponent<MeshRenderer>().material.color = color;

    }

    GameObject renderSegment(Vector3 p1,Vector3 p2)
    {
        GameObject newSegment = Instantiate(capsulePrefab, (p1 + p2)/2, Quaternion.FromToRotation(Vector3.up,p2-p1));

        newSegment.transform.localScale = new Vector3(radius, Vector3.Distance(p1,p2)/2, radius);
        newSegment.name = p1.ToString();
        newSegment.GetComponent<MeshRenderer>().material.color = color;
        

        return newSegment;
    }
}
