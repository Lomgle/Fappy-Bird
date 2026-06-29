using Unity.Mathematics;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public GameObject avatar;
    public Vector3 spinAxis;
    public float spinSpeed;
    void Update()
    {
        float angleThisFrame = spinSpeed * Time.deltaTime;
        Quaternion incrementalRotation = Quaternion.AngleAxis(angleThisFrame, spinAxis);
        avatar.transform.rotation = avatar.transform.rotation * incrementalRotation;
    }
}
