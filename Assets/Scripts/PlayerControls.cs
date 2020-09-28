using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    GameObject TargetMinion;
    //
    delegate void Del(GameObject Minion);
    Del selectedTool;
    Vector3 MousePos;
    public Button GH;
    public Button SM;
    public Button HL;
    ColorBlock selectColors;
    ColorBlock normColors;

    // Start is called before the first frame update
    void Start()
    {
        selectedTool = StubMethod;
        selectColors = GH.colors;
        normColors = SM.colors;
        GH.colors = normColors;
        HL.colors = normColors;
    }

    // Update is called once per frame
    void Update()
    {
        TargetUnderMouse();
        if(TargetMinion != null)
        {
            selectedTool(TargetMinion);
        }
    }

    void onMouseDown()
    {
        Debug.Log("Click");
        TargetUnderMouse();
        if (TargetMinion != null)
        {
            selectedTool(TargetMinion);
        }
    }

    // This is the default behavior when clicking a minion without a tool selected
    // left intionially blank
    void StubMethod(GameObject Minion)
    {
        Debug.Log("Stub called on " + Minion.tag + " Minion");
    }
    public void SetStubMethod()
    {
        selectedTool = StubMethod;
    }

    //moves minion to mouse location
    void GodHand(GameObject Minion)
    {
        Debug.Log("Calling godhand");
        Minion.GetComponent<MinionScript>().TogglePickup();
    }

    public void SetGodHand()
    {
        Debug.Log("Setting godhand");
        selectedTool = GodHand;
        GH.colors = selectColors;
        SM.colors = normColors;
        HL.colors = normColors;
    }

    //moves minion to mouse location
    void Smite(GameObject Minion)
    {
        Debug.Log("Calling Smite");
        Minion.GetComponent<MinionScript>().Hurt(5);
    }

    public void SetSmite()
    {
        Debug.Log("Setting Smite");
        selectedTool = Smite;
        GH.colors = normColors;
        SM.colors = selectColors;
        HL.colors = normColors;
    }

    void Heal(GameObject Minion)
    {
        Debug.Log("Calling Smite");
        Minion.GetComponent<MinionScript>().Hurt(-5);
    }

    public void SetHeal()
    {
        Debug.Log("Setting Heal");
        selectedTool = Heal;
        GH.colors = normColors;
        SM.colors = normColors;
        HL.colors = selectColors;
    }


    void TargetUnderMouse()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            bool gotTarget = false; //This is so we can deselect if we didn't click anything

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log("looking under mouse");
                string hitTag = hit.transform.gameObject.tag;
                if (hitTag == "Red" || hitTag == "Blue" || hitTag == "Green")// should change to check by layer
                {
                    TargetMinion = hit.transform.gameObject;
                    gotTarget = true;
                }
            }

            if (!gotTarget) TargetMinion = null; //If we missed everything, target null
        }
        else
        {
            TargetMinion = null; //untarget when not clicked
        }
    }
}
