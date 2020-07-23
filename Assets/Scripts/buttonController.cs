using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public static buttonController instance;

    public GameObject beginningHolder;
    public GameObject promptHolder;
    public GameObject postPromptHolder;
    public GameObject identityHolder;
    public GameObject matchHolder;

    public TextMeshProUGUI promptText;
    public TextMeshProUGUI questionText;

    public TextMeshProUGUI addressee;
    public TextMeshProUGUI address;

    public Button AlexandraButton;
    public Button InesButton;
    public Button MarenButton;
    public Button SiobhanButton;
    public Button SylviaButton;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        promptHolder.SetActive(false);
        postPromptHolder.SetActive(false);
        identityHolder.SetActive(false);
        matchHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginButtonPress()
    {
        beginningHolder.SetActive(false);
        identityHolder.SetActive(true);

    }

    public void IdentityButtonPress(GameObject justPressedButton)
    {
        justPressedButton.SetActive(false);
        promptHolder.SetActive(true);
        identityHolder.SetActive(false);

        SpreadsheetParser.instance.RandomPromptPicker(promptText, questionText);

    }

    public void AcceptButtonPress()
    {
        SpreadsheetParser.instance.WritePromptToFile(SpreadsheetParser.instance.currentTextIndex);
        SpreadsheetParser.instance.RemoveDictionaryKey(SpreadsheetParser.instance.currentTextIndex);

        promptHolder.SetActive(false);
        matchHolder.SetActive(true);
        addressee.text = PlayerMatcher.instance.matchedPlayerInfo.characterName;
        address.text = PlayerMatcher.instance.matchedPlayerInfo.playerAddress;

    }

    public void RejectButtonPress()
    {
        SpreadsheetParser.instance.RandomPromptPicker(promptText, questionText);
    }

    public void RestartButtonPress()
    {
        postPromptHolder.SetActive(false);
        beginningHolder.SetActive(true);

    }

    public void AcceptAddresseeButtonClick()
    {
        matchHolder.SetActive(false);
        postPromptHolder.SetActive(true);
        PlayerMatcher.instance.ResetMatchList();
        SpreadsheetParser.instance.WriteMatchToFile(PlayerMatcher.instance.matchedPlayerInfo);
        PlayerMatcher.instance.matchesSelectedThisRound.Add(PlayerMatcher.instance.matchedPlayerInfo);
        Debug.Log("I have added " + PlayerMatcher.instance.matchedPlayerInfo.playerName.ToString() + " to matchesselectedthisround");
    }

    public void NewAddresseeButtonClick()
    {
        Debug.Log("I am picking a new addressee");
        PlayerMatcher.instance.pickMatch(PlayerMatcher.instance.currentPlayerInfo);
        addressee.text = PlayerMatcher.instance.matchedPlayerInfo.characterName;
        address.text = PlayerMatcher.instance.matchedPlayerInfo.playerAddress;
    }

}
