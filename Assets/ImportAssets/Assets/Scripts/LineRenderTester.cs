using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderTester : MonoBehaviour
{

    public LineRenderer3D renderComponent;
    float currentTime = 0f;
    float loopTime = 0.3f;
    Vector3 lineFollower = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        //renderComponent.LineConstructor(lineFollower);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= loopTime)
        {
            lineFollower += new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            renderComponent.addPoint(lineFollower);
            currentTime = 0f;
        }
    }
}
