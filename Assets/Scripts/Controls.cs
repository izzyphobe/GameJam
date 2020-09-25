using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    string castleName;
    TextMeshProUGUI title;
    GameObject currentCastle;
    
    // Start is called before the first frame update
    void Start()
    {
        title = GetComponentsInChildren<TextMeshProUGUI>()[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCastle(GameObject castle){
        this.tag = castle.tag;
        Debug.Log("got switch");
        title.text = this.tag + " Castle";
        currentCastle = castle;
    }

    void ChangeSpawnRate(){
        currentCastle.SendMessage("ChangeSpawnRate");
    }

    void ChangeHP(){
        currentCastle.SendMessage("ChangeHP");
    }

    void ChangeSpeed(){
        currentCastle.SendMessage("ChangeSpeed");
    }
}
