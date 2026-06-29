using UnityEngine;
using UnityEngine.Rendering;

public class PipeSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pipe;
    public BirdScript bird;
    public float spawnRate = 2;
    private float timer = 0;

    public float heighOffset = 3;
    void Start()
    {
        spawnPipe();
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }
    void spawnPipe()
    {
        float lowestHeight = transform.position.y - heighOffset;
        float highestHeight = transform.position.y + heighOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestHeight, highestHeight), 0), transform.rotation);
    }
    void Update()
    {
        if (timer >= spawnRate && bird.LiveState())
        {
            spawnPipe();
            timer = 0;
        } else timer += Time.deltaTime;
        
    }

}
