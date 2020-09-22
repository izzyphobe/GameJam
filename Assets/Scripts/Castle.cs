using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private float rate = 1;
   [SerializeField] private float delay = 0;
    private int minionCap;
    public GameObject prefab;
   

    // Start is called before the first frame update
    void Start()
    {
        minionCap = 5;
        InvokeRepeating("Spawn",delay,rate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        GameObject child;
        if(transform.childCount < minionCap){
            child = Instantiate(prefab, transform);
            child.tag = this.tag;
        }
        
    }
}
