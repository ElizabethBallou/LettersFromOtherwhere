using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public static buttonController instance;
    public TextMeshProUGUI titleText;
    public Button beginButton;
    public TextMeshProUGUI writeLetterAbout;
    public TextMeshProUGUI promptText;
    public TextMeshProUGUI questionText;
    public Button acceptPromptButton;
    public Button rejectPromptButton;
    public TextMeshProUGUI postPickText;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        promptText.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        acceptPromptButton.gameObject.SetActive(false);
        rejectPromptButton.gameObject.SetActive(false);
        writeLetterAbout.gameObject.SetActive(false);
        postPickText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginButtonPress()
    {
        titleText.gameObject.SetActive(false);
        beginButton.gameObject.SetActive(false);
        writeLetterAbout.gameObject.SetActive(true);
        promptText.gameObject.SetActive(true);
        questionText.gameObject.SetActive(true);
        acceptPromptButton.gameObject.SetActive(true);
        rejectPromptButton.gameObject.SetActive(true);

        SpreadsheetParser.instance.RandomPromptPicker(promptText, questionText);
    }

    public void AcceptButtonPress()
    {
        Debug.Log("RUNNING ACCEPTBUTTONPRESS");
        SpreadsheetParser.instance.RemoveDictionaryKey(SpreadsheetParser.instance.currentTextIndex);
        promptText.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        acceptPromptButton.gameObject.SetActive(false);
        rejectPromptButton.gameObject.SetActive(false);
        writeLetterAbout.gameObject.SetActive(false);
        postPickText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void RejectButtonPress()
    {
        Debug.Log("RUNNING REJECTBUTTONPRESS");
        SpreadsheetParser.instance.RandomPromptPicker(promptText, questionText);
    }

    public void RestartButtonPress()
    {
        postPickText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        beginButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);

    }

}
