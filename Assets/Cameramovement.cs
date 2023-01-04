using UnityEngine;

public class Cameramovement : MonoBehaviour

{
    public Transform target;
    public Vector3 cameraoffset;
    public float followspeed = 10f;
    public float xMin = 0f;
    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position + cameraoffset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followspeed * Time.fixedDeltaTime);

        transform.position = smoothPos; 
    }
}
