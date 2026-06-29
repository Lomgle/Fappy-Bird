using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Trigger : MonoBehaviour
{
    public Logic logic;
    public int scoreToAdd = 1;
    public BirdScript bird;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && bird.LiveState()) logic.addScore(scoreToAdd);
    }
}
