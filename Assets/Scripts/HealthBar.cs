using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    SpriteRenderer spriteRenderer;

    GameObject parentobj;

    MinionScript parent;
    // Start is called before the first frame update
    void Start()
    {
        parentobj = transform.parent.gameObject;
        localScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = parentobj.GetComponent<MinionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = parent.health * 0.5f;
        transform.localScale = localScale;
        spriteRenderer.color = getColor(parent.health);
    }

    private Color getColor(float health){
        if(health > 0.5f) return Color.green;
        else return Color.red;
    }
}
