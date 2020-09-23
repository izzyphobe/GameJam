using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        BlueText = transform.Find("BlueText").gameObject;
        RedText = transform.Find("RedText").gameObject;
        GreenText = transform.Find("GreenText").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int blueCount = BlueSpawn.gameObject.transform.childCount;
        BlueText.GetComponent<UnityEngine.UI.Text>().text = "Blue: " + blueCount;
        int redCount = RedSpawn.gameObject.transform.childCount;
        RedText.GetComponent<UnityEngine.UI.Text>().text = "Red: " + redCount;
        int greenCount = GreenSpawn.gameObject.transform.childCount;
        GreenText.GetComponent<UnityEngine.UI.Text>().text = "Green: " + greenCount;
    }
}
