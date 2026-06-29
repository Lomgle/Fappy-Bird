using System.Threading;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloud;

    public BirdScript bird;
    public float timer = 0;
    public float spawnRate = 3;
    public float heighOffset = 5;
    public void spawnCloud()
    {
        float lowestHeight = transform.position.y - heighOffset;
        float highestHeight = transform.position.y + heighOffset;
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestHeight, highestHeight), 0), transform.rotation);
    }
    void Start()
    {
         bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    void Update()
    {
        if (timer >= spawnRate && bird.LiveState())
        {
            spawnCloud();
            timer = 0;
        } else timer += Time.deltaTime;
        
    }
}
