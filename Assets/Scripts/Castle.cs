using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private float rate = 0.5f;
   [SerializeField] private float delay = 0;
    private int minionCap;
    public GameObject prefab;
    private MinionScript minion;
    float minSpawn = 0.5f;
    float maxSpawn = 2f;


    // Start is called before the first frame update
    void Start()
    {
        minion = prefab.GetComponent<MinionScript>();
        prefab.GetComponent<MinionScript>().maxhealth = 10;
        prefab.GetComponent<MinionScript>().speed = 0.5f;
        minionCap = 5000;
        //InvokeRepeating("Spawn",delay,rate);
        StartCoroutine(SpawnWithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWithCoroutine(){
        while (true)
        {
            var delay = Random.Range(minSpawn, maxSpawn);
            Debug.Log("callingSpawn. delay till next call:" + delay);
            GameObject NewChild = Instantiate(prefab, transform);
            NewChild.tag = this.tag;
            yield return new WaitForSeconds(delay);
        }
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
