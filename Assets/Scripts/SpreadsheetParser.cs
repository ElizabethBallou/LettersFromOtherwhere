using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpreadsheetParser : MonoBehaviour
{
    public static SpreadsheetParser instance;
    private TextAsset promptSpreadsheet;
    private Dictionary<int, string[]> promptDictionary;
    private int dictionaryIDAssigner = 0;
    [HideInInspector]
    public int currentTextIndex = 0;
    private bool pickNewNum = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        promptDictionary = new Dictionary<int, string[]>();
        promptSpreadsheet = Resources.Load<TextAsset>("LFO prompts");
        string[] rowEntries = promptSpreadsheet.text.Split('\n');
        
        foreach (string row in rowEntries)
        {
            string[] rowCells = row.Split('\t');
            promptDictionary.Add(dictionaryIDAssigner, rowCells);
            dictionaryIDAssigner++;
        }

        Debug.Log("The count of promptDictionary is " + promptDictionary.Count);

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
        Debug.Log("The length of keys is " + keys.Count);
        int rand = keys[Random.Range(0, keys.Count)];
        return rand;
       
    }


    public void RemoveDictionaryKey(int index)
    {
        promptDictionary.Remove(index);
    }
}
