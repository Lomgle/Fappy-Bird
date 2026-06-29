using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float MoveSpeed;
    public float DestroyZoneCloud = -25;

    void DestroyCloud()
    {
        if (transform.position.x <= DestroyZoneCloud)
        {
            Destroy(gameObject);
            Debug.Log("cloud gone");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        DestroyCloud();
    }
}
