using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class minionCounter : MonoBehaviour
{
    public GameObject BlueSpawn;
    GameObject BlueText;
    public GameObject RedSpawn;
    GameObject RedText;
    public GameObject GreenSpawn;
    GameObject GreenText;



    // Start is called before the first frame update
    void Start()
    {
        BlueText = GameObject.Find("BlueText").gameObject;
        RedText = GameObject.Find("RedText").gameObject;
        GreenText = GameObject.Find("GreenText").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int blueCount = BlueSpawn.gameObject.transform.childCount;
        BlueText.GetComponent<TextMeshProUGUI>().text = "" + blueCount;
        int redCount = RedSpawn.gameObject.transform.childCount;
        RedText.GetComponent<TextMeshProUGUI>().text =""+  redCount;
        int greenCount = GreenSpawn.gameObject.transform.childCount;
        GreenText.GetComponent<TextMeshProUGUI>().text =""+ greenCount;
    }
}
