using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private float minSpawn = .2f;
    private float maxSpawn = .5f;
    public float health, maxhealth;

    private int xp, level;



    // Start is called before the first frame update
    void Start()
    {

        maxhealth = health = 10f;
        minion = prefab.GetComponent<MinionScript>();
        //minion.maxhealth = 200f;
        //minion.speed = 0.5f;
        minionCap = 5000;
        //InvokeRepeating("Spawn",delay,rate);
        StartCoroutine(SpawnWithCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWithCoroutine(){
        var count = Random.Range(8, 13);
        int bias = Random.Range(-1, 2) *5;
        var bReset = 10;
        while (true)
        {
            if (count-- == 0)
            {
                if (bReset-- == 0)
                {
                    bias= Random.Range(-1, 2)*3*level;
                    bReset = 10;
                }
                count = Random.Range(level*3+5,3*level+10)+bias;
                yield return new WaitForSeconds(Random.Range(5f,8f));
            }
            else
            {
                var delay = Random.Range(minSpawn, maxSpawn);
                //Debug.Log("callingSpawn. delay till next call:" + delay);
                GameObject NewChild = Instantiate(prefab, transform);
                MinionScript childScript = NewChild.GetComponent<MinionScript>();
                NewChild.tag = this.tag;
                for (int i = 1; i < level; i++) if(Random.Range(0f,1f)>.4f) childScript.LevelUp();
                childScript.health = childScript.maxhealth;
               //Debug.Log("spawn l" + childScript.level + "  h" + childScript.health + "  a" + childScript.attack);
                yield return new WaitForSeconds(.3f);
                
            }
        }
    }

    public void gainXP(int xpGained = 1)
    {
        while(Mathf.Pow(3f, level) <= (xp+= xpGained)) LevelUp();
    }

    public void LevelUp()
    {
        level++;
        xp -= (int) Mathf.Pow(3f, level);
        
    }
    public bool Hurt(int damage = 1){
        //Debug.Log(gameObject.tag + " minion hurt");
        health = health - damage;
        if(health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    void Die(){
        //Debug.Log(gameObject.tag + " minion died");
        Time.timeScale = 0;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);

    }

}
