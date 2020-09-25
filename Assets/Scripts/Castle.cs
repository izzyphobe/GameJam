using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject controls;
   

    // Start is called before the first frame update
    void Start()
    {
        controls = GameObject.Find("PlayerControls");
        minion = prefab.GetComponent<MinionScript>();
        prefab.GetComponent<MinionScript>().maxhealth = 6;
        minionCap = 5;
        InvokeRepeating("Spawn",delay,rate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        controls.SendMessage("SwitchCastle", this.gameObject);
    }

    void Spawn(){
        GameObject child;
        // if(transform.childCount < minionCap){
            child = Instantiate(prefab, transform);
            child.tag = this.tag;
        // }
        
    }

    public void ChangeSpawnRate(){
        rate*=1.2f;
    }
    
    public void ChangeHP(){
        minion.maxhealth +=1;
    }

    public void ChangeSpeed(){
        minion.speed *= 1.2f;
    }

    void ChangeBounce(){
    
    }

    void ChangeCap(){
        minionCap++;
    }
}
