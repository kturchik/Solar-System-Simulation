using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapControl : MonoBehaviour {

    public float panBorderWidth = 10f;
    public float zoomMin = 20f;
    public float zoomMax = 60f;
    public float zoomSpeed = 1f;
    public float scrollMin = 70f;
    public float scrollMax = 140f;
    public float scrollSpeed = 1f;

    private Vector3 pos;


	// Use this for initialization
	void Start () {
        pos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {

        if ((Input.mousePosition.y) < Screen.height * GetComponent<Camera>().rect.height)
        {
            // Zoom
            if ((Input.GetKey("w") || Input.GetKey("up") || Input.GetAxis("Mouse ScrollWheel") > 0))
            {
                GetComponent<Camera>().orthographicSize -= zoomSpeed;
                if (GetComponent<Camera>().orthographicSize < zoomMin)
                {
                    GetComponent<Camera>().orthographicSize = zoomMin;
                }
            }
            if ((Input.GetKey("s") || Input.GetKey("down") || Input.GetAxis("Mouse ScrollWheel") < 0))
            {
                GetComponent<Camera>().orthographicSize += zoomSpeed;
                if (GetComponent<Camera>().orthographicSize > zoomMax)
                {
                    GetComponent<Camera>().orthographicSize = zoomMax;
                }
            }

            // Side Scroll
            if ((Input.GetKey("a") || Input.GetKey("left") || Input.mousePosition.x <= panBorderWidth))
            {
                pos.x -= scrollSpeed * Time.deltaTime;
                if (pos.x < scrollMin)
                {
                    pos.x = scrollMin;
                }
                transform.localPosition = pos;
            }
            if ((Input.GetKey("d") || Input.GetKey("right") || Input.mousePosition.x >= Screen.width - panBorderWidth))
            {
                pos.x += scrollSpeed * Time.deltaTime;
                if (pos.x > scrollMax)
                {
                    pos.x = scrollMax;
                }
                transform.localPosition = pos;
            }
        }
    }
}
