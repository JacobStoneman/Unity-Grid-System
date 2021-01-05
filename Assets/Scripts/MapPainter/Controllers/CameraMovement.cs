using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;
    public int camStep = 1;
    public BoolVariable UIInteraction;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScroll();
        CheckInput();
    }

    void CheckScroll()
	{
        if (!UIInteraction.value)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                cam.orthographicSize--;
            }
            else if (d < 0f)
            {
                cam.orthographicSize++;
            }
            if (cam.orthographicSize <= 0)
            {
                cam.orthographicSize = 1;
            }
        }
    }

    void CheckInput()
	{
        if (!UIInteraction.value)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + camStep * Time.deltaTime, transform.position.z);
                transform.position = newPos;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y - camStep * Time.deltaTime, transform.position.z);
                transform.position = newPos;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 newPos = new Vector3(transform.position.x - camStep * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 newPos = new Vector3(transform.position.x + camStep * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
