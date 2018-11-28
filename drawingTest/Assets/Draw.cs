using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour {

    public GameObject pixel;
    public GameObject corner;
    public Canvas canvas;
    private Vector2 mousePosition;
    private GameObject line;
    private GameObject pix;

    private bool mouseDown;
    private bool objectCreated;

    // Use this for initialization
    void Start () {
        mouseDown = false;
        objectCreated = false;
	}
	
	// Update is called once per frame
	void Update () {
       if (Input.GetMouseButtonDown(0) && !mouseDown)
        {
            mouseDown = true;
            mousePosition = Input.mousePosition;
            pix = Instantiate(corner, Input.mousePosition, Quaternion.Euler(0.0f, 0.0f, 0.0f), canvas.transform);
        }

        if (mouseDown)
        {
            mousePosition = Input.mousePosition;
            if (!objectCreated)
            {
                objectCreated = true;
                line = Instantiate(pixel, Input.mousePosition, Quaternion.identity, canvas.transform);
                line.GetComponent<RectTransform>().pivot = new Vector2(0.0f, 0.5f);
            }
            RectTransform rt = line.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(Vector2.Distance(line.transform.position, mousePosition), rt.sizeDelta.y);
            rt.transform.rotation = Quaternion.FromToRotation(Vector2.right, mousePosition - new Vector2(line.transform.position.x, line.transform.position.y));
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            objectCreated = false;
        }
	}
}
