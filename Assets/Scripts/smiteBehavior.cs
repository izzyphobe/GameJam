using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smiteBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject aoe;
    bool active = false;
   // GameObject aoe;
    Collider2D col;
    int timer=0;
    bool killing = false;
    SpriteRenderer rend;
    Color normC;

    void Start()
    {
       // aoe = GetComponent<GameObject>();
        aoe.SetActive(false);
        col = GetComponent<Collider2D>();
        col.enabled=false;
        rend = GetComponent<SpriteRenderer>();
        normC = rend.color;
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
                if (killing)
                {
                    endKill();
                }
                else
                {
                    kill();
                }
            }
        }
    }

    public void go()
    {
        if (!active)
        {
            active = true;
            timer = 50;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            transform.position = mousePos2D;
            aoe.SetActive(true);
        }
        
    }

    public void kill()
    {
        col.enabled = true;
        killing = true;
        timer = 10;
        rend.color = Color.red;

    }

    public void endKill()
    {
        col.enabled = false;
        killing = false;
        active = false;
        aoe.SetActive(false);
        rend.color = normC;

    }
}
