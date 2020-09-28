using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    Vector3 localScale;
    SpriteRenderer spriteRenderer;

    GameObject parentobj;

    Castle parent;
    // Start is called before the first frame update
    void Start()
    {
        parentobj = transform.parent.gameObject;
        localScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = parentobj.GetComponent<Castle>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(parent.health / parent.maxhealth);
        localScale.x = parent.health / parent.maxhealth;
        transform.localScale = localScale;
        spriteRenderer.color = getColor(parent.health);
    }

    private Color getColor(float health){
        if((parent.health / parent.maxhealth) > 0.5f) return Color.green;
        else return Color.red;
    }
}
