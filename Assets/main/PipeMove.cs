using UnityEngine;

public class PipeMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float MoveSpeed;
    public float DestroyZone = -25;
    void Start()
    {
        
    }
    void DestroyPipe()
    {
        if (transform.position.x < DestroyZone) {
            Destroy(gameObject);
            Debug.Log("pipe gone");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        DestroyPipe();
    }
}
