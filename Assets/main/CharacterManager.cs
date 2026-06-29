using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public Text nameText;
    public Text descText;
    public SpriteRenderer birdSprite;
    private int selectedOption = 0;
    void Start()
    {
        if (PlayerPrefs.HasKey("selectedOption")) Load();
        else selectedOption = 0;
        UpdateCharacter(selectedOption);
    }

    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame) BackOption();
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame) NextOption();
    }
    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        nameText.text = character.CharacterName;
        descText.text = character.CharacterDesc;
        birdSprite.sprite = character.CharacterSprite;
        Save();
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
