using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{
    private GameObject anchor;
    public GameObject drawPrefab;
    public float currentTime = 0f;
    public float drawInterval = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("Plane");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= drawInterval)
        {
            //Instantiate(drawPrefab, gameObject.transform.position, gameObject.transform.rotation, anchor.transform);
            Instantiate(drawPrefab, gameObject.transform.position, gameObject.transform.rotation);
            currentTime = 0;
        }
        
    }
}
