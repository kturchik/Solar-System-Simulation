using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;
    public GameObject target; // the target that the camera should look at
    private Vector3 pos;

    public float panBorderWidth = 10f;
    public float zoomMin = 20f;
    public float zoomMax = 60f;
    public float zoomSpeed = 1f;
    public float scrollMin = 70f;
    public float scrollMax = 140f;
    public float scrollSpeed = 1f;

    private float distanceToPos;
    private bool movingToTarget;

    // Use this for initialization
    void Start()
    {
        instance = this;

        if (target == null)
        {
            pos = transform.position;

            target = this.gameObject;
            Debug.Log("LookAtTarget target not specified. Defaulting to parent GameObject");
        }
        if (target)
        {
            pos.x = target.transform.position.x;
            pos.y = target.transform.localScale.y * 5f;
            pos.z = 0;
            transform.position = pos;
            transform.LookAt(target.transform);
        }
    }

    public void ChangeTarget(GameObject newTarget) {
        Vector3 heading = transform.position - target.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading/distance;

        target = newTarget;

        pos = target.transform.position + (direction * target.transform.localScale.x * 5f);
        distanceToPos = Vector3.Distance(transform.position, pos);
        movingToTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos)
        {
            movingToTarget = false;
        }

        if (movingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, distanceToPos/2 * Time.deltaTime);
        }


        if (!movingToTarget && (Input.mousePosition.y) > Screen.height - Screen.height * GetComponent<Camera>().rect.height)
        {
            // Zoom
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                GetComponent<Camera>().fieldOfView--;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                GetComponent<Camera>().fieldOfView++;
            }

            // Scroll
            if ((Input.GetKey("w") || Input.GetKey("up")))
            {
                transform.RotateAround(target.transform.position, transform.TransformDirection(Vector3.right), scrollSpeed * Time.deltaTime);
            }
            if ((Input.GetKey("s") || Input.GetKey("down")))
            {
                transform.RotateAround(target.transform.position, transform.TransformDirection(Vector3.right), -scrollSpeed * Time.deltaTime);
            }
            if ((Input.GetKey("a") || Input.GetKey("left")))
            {
                transform.RotateAround(target.transform.position, Vector3.up, scrollSpeed * Time.deltaTime);
            }
            if ((Input.GetKey("d") || Input.GetKey("right")))
            {
                transform.RotateAround(target.transform.position, Vector3.up, -scrollSpeed * Time.deltaTime);
            }
        }
    }
}
