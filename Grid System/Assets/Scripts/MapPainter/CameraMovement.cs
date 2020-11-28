using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckScroll();
    }

    void CheckScroll()
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
        if(cam.orthographicSize<= 0)
		{
            cam.orthographicSize = 1;
		}

		if (Input.GetMouseButton(2))
		{
            
		}
    }
}
