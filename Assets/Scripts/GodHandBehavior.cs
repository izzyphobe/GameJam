using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodHandBehavior : MonoBehaviour
{

    bool holding=false;
    GameObject inHand = null;
    public double range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void go()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        if (inHand!=null)
        {
            inHand.GetComponent<MinionScript>().SendMessage("TogglePickup");
            inHand = null;
        }
        else
        {
            List<GameObject> gos = new List<GameObject>();

            gos.AddRange(GameObject.FindGameObjectsWithTag("Red"));

            gos.AddRange(GameObject.FindGameObjectsWithTag("Blue"));

            gos.AddRange(GameObject.FindGameObjectsWithTag("Green"));


            GameObject closest = null;
            float distance = Mathf.Infinity;
            
            foreach (GameObject go in gos)
            {
                if (!go.isStatic)
                {
                    Vector3 position = go.transform.position;
                    Vector2 position2d = new Vector2(position.x, position.y);
                   // Debug.Log("m" + mousePos + "  e" + position);
                    Vector3 diff = mousePos2D- position2d;
                    float curDistance = diff.sqrMagnitude;
                    //Debug.Log(curDistance);
                    if (curDistance < distance)
                    {
                        closest = go;
                        distance = curDistance;
                    }
                }
            }
            Debug.Log("hand done looking");
            if (closest != null && distance < range) 
            {
                Debug.Log("found" + closest.tag);
                closest.GetComponent<MinionScript>().SendMessage("TogglePickup");
                inHand = closest;
            }
        }
    }
}
