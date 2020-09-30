using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aoe;
    bool active = false;
    // GameObject aoe;
    Collider2D col;
    int timer = 0;
 

    void Start()
    {
        // aoe = GetComponent<GameObject>();
        aoe.SetActive(false);
        col = GetComponent<Collider2D>();
        col.enabled = false;
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (active)
        {
            timer--;
            if (timer < 0)
            {
                endHeal();
                    
            }
        }
    }

    public void go()
    {
        if (!active)
        {
            active = true;
            timer = 100;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            transform.position = mousePos2D;
            aoe.SetActive(true);
            col.enabled = true;
        }

    }


    public void endHeal()
    {
        col.enabled = false;
        active = false;
        aoe.SetActive(false);
  

    }
}
