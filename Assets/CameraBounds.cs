using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

//this is also a camera follow script
public class CameraBounds : MonoBehaviour
{
    Transform target;
    public GameObject Player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValues;

    void Start()
    {
        target = Player.transform;
    }

    void Update()
    {
        // 20:9 Landscape aspect ratio
        if (Camera.main.aspect >= 2.22)
        Camera.main.orthographicSize = 5.2f;

        // 19.5:9 Landscape aspect ratio
        else if (Camera.main.aspect >= 2.16)
        Camera.main.orthographicSize = 5.3f;

        // 19:9 Landscape aspect ratio
        else if (Camera.main.aspect >= 2.1)
        Camera.main.orthographicSize = 5.4f;

        // 18:9 Landscape aspect ratio
        else if (Camera.main.aspect >= 2)
        Camera.main.orthographicSize = 5.72f;

        // 16:9 Landscape aspect ratio
        else if (Camera.main.aspect >= 1.78)
        Camera.main.orthographicSize = 6.4f;

        // 1080/720 Landscape aspect ratio
        else if (Camera.main.aspect >= 0.67)
        Camera.main.orthographicSize = 6.5f;

    }

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        //verify if the targetPosition is out of bounds or not
        //Limit it to the min max values
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, targetPosition.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z)
            );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
