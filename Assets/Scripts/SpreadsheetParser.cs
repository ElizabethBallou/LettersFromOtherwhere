using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class SpreadsheetParser : MonoBehaviour
{
    public static SpreadsheetParser instance;
    public TextAsset promptSpreadsheet;
    private Dictionary<int, string[]> promptDictionary;
    private int dictionaryIDAssigner = 0;
    [HideInInspector]
    public int currentTextIndex = 0;
    private bool pickNewNum = false;
    private string path;
    private bool firstTimeWritingToFile = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        promptDictionary = new Dictionary<int, string[]>();
        string[] rowEntries = promptSpreadsheet.text.Split('\n');
        
        foreach (string row in rowEntries)
        {
            string[] rowCells = row.Split('\t');
            promptDictionary.Add(dictionaryIDAssigner, rowCells);
            dictionaryIDAssigner++;
        }

        Debug.Log("The count of promptDictionary is " + promptDictionary.Count);

       path = Application.dataPath + "/AssignmentLog.txt";

    }

    // Update is called once per frame
    void Update()
    {
       
    }
        

    public void RandomPromptPicker(TextMeshProUGUI prompt, TextMeshProUGUI questions)
    {
    
        currentTextIndex = RandomNumGen();
        string[] holderTextArray = promptDictionary[currentTextIndex];
            prompt.text = holderTextArray[0];
            questions.text = holderTextArray[1];
        

    }

    public int RandomNumGen()
    {

        List<int> keys = new List<int>(promptDictionary.Keys);
        int rand = keys[Random.Range(0, keys.Count)];
        return rand;
       
    }


    public void RemoveDictionaryKey(int index)
    {
        promptDictionary.Remove(index);
    }

    public void WritePromptToFile(int index)
    {
        string thisDictKey = "";
        string[] tempStringArrayHolder = promptDictionary[index];
        for (int k = 0; k < tempStringArrayHolder.Length; k++)
        {
            thisDictKey = thisDictKey + tempStringArrayHolder[k] + " ";
        }
        
        File.AppendAllText(path, thisDictKey);
        Debug.Log("Just added to file: " + thisDictKey);
    }

    public void WriteNameToFile(string camperName)
    {
        if (firstTimeWritingToFile)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Letter writer: " + camperName + "\n");
            }
            else
            {
                File.WriteAllText(path, "");
                File.AppendAllText(path, "Letter writer: " + camperName + "\n");
            }

            firstTimeWritingToFile = false;
        }
        else
        {
            File.AppendAllText(path, "Letter writer: " + camperName + "\n");
        }
    }

    public void WriteMatchToFile(PlayerInfo matchedPlayerInfo)
    {
        File.AppendAllText(path, "Addressee name: " + matchedPlayerInfo.playerName.ToString() + "\n" + "Addressee's character: " + matchedPlayerInfo.characterName + "\n" + "Address: " + matchedPlayerInfo.playerAddress + "\n" + "\n");
    }
}
