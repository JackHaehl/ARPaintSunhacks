using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DrawingPen : MonoBehaviour
{
    public GameObject drawingPrefab;
    LineRenderer3D currentLine;
    public Transform penTipPoint;
    public TextMeshProUGUI buttonText;
    public Color currentColor = new Color(1, 1, 1);
    public float currentRadius = 0.02f;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Slider radiusSlider;

    bool isDrawing = false;
    float drawLoopTime = 0.2f;
    float currentTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.FindGameObjectWithTag("DrawPoint").transform.position;
        if (isDrawing)
        {
            currentTime += Time.deltaTime;
            if(currentTime >= drawLoopTime)
            {
                currentTime = 0f;
                Draw();
            }
        } 
    }

    public void DrawButton()
    {
        isDrawing = !isDrawing;
        if (isDrawing)
        {
            GameObject newLineRenderer = Instantiate(drawingPrefab, penTipPoint.position, Quaternion.identity);
            currentLine = newLineRenderer.GetComponent<LineRenderer3D>();
            currentLine.LineConstructor(penTipPoint.position,currentColor,currentRadius);
        }
        else
        {
           
        }
    }

    private void Draw()
    {
        currentLine.addPoint(penTipPoint.position);
    }

    public void UpdateSliders()
    {
        currentRadius = radiusSlider.value;
        currentColor = new Color(redSlider.value, greenSlider.value, blueSlider.value);
    }
}
