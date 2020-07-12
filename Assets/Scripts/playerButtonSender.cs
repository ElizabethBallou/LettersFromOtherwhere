using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerButtonSender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passButtonNameOn()
    {
        SpreadsheetParser.instance.WriteNameToFile(this.name);
        PlayerMatcher.instance.EstablishPlayer(this.name);
        buttonController.instance.IdentityButtonPress(this.gameObject);
    }
}
