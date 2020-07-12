using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMatcher : MonoBehaviour
{
    public static PlayerMatcher instance;

    public PlayerInfo InesInfo;
    public PlayerInfo MarenInfo;
    public PlayerInfo SiobhanInfo;
    public PlayerInfo AmiraInfo;
    public PlayerInfo AlexandraInfo;
    public PlayerInfo SylviaInfo;
    private PlayerInfo currentPlayerInfo;
    [HideInInspector] public PlayerInfo matchedPlayerInfo;
    private PlayerInfo[] allPlayerInfos;
    private List<PlayerInfo> possibleMatches;
    private List<PlayerInfo> matchesSelectedThisRound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        possibleMatches = new List<PlayerInfo>();
        allPlayerInfos = new PlayerInfo[] { InesInfo, MarenInfo, SiobhanInfo, AmiraInfo, AlexandraInfo, SylviaInfo };
        possibleMatches = allPlayerInfos.ToList();
        matchesSelectedThisRound = new List<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pickMatch(PlayerInfo thisPlayerInfo)
    {

        for (int i = 0; i < possibleMatches.Count; i++)
        {
            if (possibleMatches[i].playerName == thisPlayerInfo.playerName)
            {
                Debug.Log("Removing " + possibleMatches[i].playerName.ToString() + " because this player IS " + thisPlayerInfo.playerName.ToString());
                possibleMatches.Remove(possibleMatches[i]);
            }   
        }
        
        for (int j = 0; j < possibleMatches.Count; j++)
            {
                for (int k = 0; k < thisPlayerInfo.alreadyWrittenTo.Length; k++)
                {
                    if (possibleMatches[j].playerName == thisPlayerInfo.alreadyWrittenTo[k])
                    {
                    Debug.Log("Removing " + possibleMatches[j].playerName.ToString() + " because " + thisPlayerInfo.playerName.ToString() + "has already written to " + possibleMatches[j].playerName.ToString());
                    possibleMatches.Remove(possibleMatches[j]);
                    }
                }
            }

        if (matchesSelectedThisRound.Count >= 1)
        {
            for (int l = 0; l < matchesSelectedThisRound.Count; l++)
            {
                for (int m = 0; m < possibleMatches.Count; m++)
                {
                    if (matchesSelectedThisRound[l].playerName == possibleMatches[m].playerName)
                    {
                        Debug.Log("Removing " + possibleMatches[m].playerName.ToString() + " because they have already been selected this round.");
                        possibleMatches.Remove(possibleMatches[m]);
                    }
                }
                
            }
        }

        matchedPlayerInfo = possibleMatches[Random.Range(0, possibleMatches.Count-1)];
        Debug.Log("I have picked a match, and it is " + matchedPlayerInfo.playerName.ToString());

        matchesSelectedThisRound.Add(matchedPlayerInfo);
        Debug.Log("I have added " + matchedPlayerInfo.playerName.ToString() + " to matchesselectedthisround");


    }

        public void EstablishPlayer(string buttonTitle)
        {
            switch (buttonTitle)
            {
                case "Ines":
                    currentPlayerInfo = InesInfo;
                    break;
                case "Maren":
                    currentPlayerInfo = MarenInfo;
                    break;
                case "Siobhan":
                    currentPlayerInfo = SiobhanInfo;
                    break;
                case "Amira":
                    currentPlayerInfo = AmiraInfo;
                    break;
                case "Alexandra":
                    currentPlayerInfo = AlexandraInfo;
                    break;
                case "Sylvia":
                    currentPlayerInfo = SylviaInfo;
                    break;
            }
            Debug.Log("According to EstablishPlayer, currentPlayerInfo is " + currentPlayerInfo.playerName.ToString());
            pickMatch(currentPlayerInfo);
        }

    public void ResetMatchList()
    {
        possibleMatches.Clear();
        possibleMatches = allPlayerInfos.ToList();
    }

}

    [System.Serializable]
    public class PlayerInfo
    {
        public enum nameEnum
        {
            Ines,
            Maren,
            Siobhan,
            Amira,
            Alexandra,
            Sylvia
        };
        public nameEnum playerName;
        public string playerAddress;
        public string characterName;
        public nameEnum[] alreadyWrittenTo;
    }
