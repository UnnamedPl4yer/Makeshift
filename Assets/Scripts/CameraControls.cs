using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private GameObject bird;
    private GameObject fox;
    private float smoothSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindWithTag("Bird");
        fox = GameObject.FindWithTag("Fox");
    }

    // Update is called once per frame
    void Update()
    {
        float distx = (bird.transform.position.x - fox.transform.position.x);
        distx = Mathf.Sqrt(distx * distx);

        float disty = (bird.transform.position.y - fox.transform.position.y);
        disty = Mathf.Sqrt(disty * disty);

        if (distx > 2 * Mathf.Abs(transform.position.z))
        {
            float maxx = 0;
            float newy = 0;
            if (bird.transform.position.x > fox.transform.position.x)
            {
                maxx = bird.transform.position.x;
                newy = bird.transform.position.y;
            }
            else
            {
                maxx = fox.transform.position.x;
                newy = fox.transform.position.y;
            }
            Vector3 desiredPosition = new Vector3(maxx, newy, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            float minX = Mathf.Min(bird.transform.position.x, fox.transform.position.x);
            float minY = Mathf.Min(bird.transform.position.y, fox.transform.position.y);

            float newX = minX + 0.5f * distx;
            float newY = minY + 0.5f * disty + 1.25f;

            Vector3 desiredPosition = new Vector3(newX, newY, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
