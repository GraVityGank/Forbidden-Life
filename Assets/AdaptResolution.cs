using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptResolution : MonoBehaviour
{
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
}
