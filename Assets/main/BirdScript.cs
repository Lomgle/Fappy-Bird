using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public float Strength;
    public Logic logic;
    public float lim = -13;
    public bool isAlive = true;
    public CharacterDatabase characterDB;
    public int selectedOption = 0;
    public SpriteRenderer birdSprite;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
        if (!PlayerPrefs.HasKey("selectedOption")) selectedOption = 0;
        else Load();
        UpdateCharacter(selectedOption);
        Debug.Log(selectedOption);
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        birdSprite.sprite = character.CharacterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    void Death()
    {
        logic.gameOver();
        isAlive = false;
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame == true && isAlive)
        {
            birdRigidBody.linearVelocity = Vector2.up * 10;
        }
        if (birdRigidBody.transform.position.y <= lim || birdRigidBody.transform.position.y >= -lim)
        {
            Death();
        }
    }
    public bool LiveState()
    {
        if (isAlive) return true;
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }
}
