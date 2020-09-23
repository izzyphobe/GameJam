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
    private MinionScript minion;
   

    // Start is called before the first frame update
    void Start()
    {
        minion = prefab.GetComponent<MinionScript>();
        prefab.GetComponent<MinionScript>().maxhealth = 6;
        minionCap = 5;
        InvokeRepeating("Spawn",delay,rate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        GameObject child;
        // if(transform.childCount < minionCap){
            child = Instantiate(prefab, transform);
            child.tag = this.tag;
        // }
        
    }

    void ChangeSpawnRate(){
        rate*=1.2f;
    }
    
    void ChangeHP(){
        minion.maxhealth +=1;
    }

    void ChangeSpeed(){
        minion.speed *= 1.2f;
    }

    void ChangeBounce(){
    
    }

    void ChangeCap(){
        minionCap++;
    }
}
