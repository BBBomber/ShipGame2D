using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    float cameraWidth;
    float cameraHeight;

    void Start()
    {
        // Calculate camera width and height
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    void Update()
    {
        // Check if the object is outside the camera bounds
        WrapIfOutsideBounds();
    }

    void WrapIfOutsideBounds()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x > Camera.main.transform.position.x + cameraWidth)
        {
            // If object is to the right of the camera, move it to the left
            newPosition.x = Camera.main.transform.position.x - cameraWidth;
        }
        else if (transform.position.x < Camera.main.transform.position.x - cameraWidth)
        {
            // If object is to the left of the camera, move it to the right
            newPosition.x = Camera.main.transform.position.x + cameraWidth;
        }

        if (transform.position.y > Camera.main.transform.position.y + cameraHeight)
        {
            // If object is above the camera, move it below
            newPosition.y = Camera.main.transform.position.y - cameraHeight;
        }
        else if (transform.position.y < Camera.main.transform.position.y - cameraHeight)
        {
            // If object is below the camera, move it above
            newPosition.y = Camera.main.transform.position.y + cameraHeight;
        }

        // Apply the new position
        transform.position = newPosition;
    }
}
