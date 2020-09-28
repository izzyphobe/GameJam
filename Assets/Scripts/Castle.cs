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
    private float minSpawn = 1f;
    private float maxSpawn = 2f;
    public float health, maxhealth;

    private int xp, level;



    // Start is called before the first frame update
    void Start()
    {

        maxhealth = health = 10f;
        minion = prefab.GetComponent<MinionScript>();
        minion.maxhealth = 10;
        minion.speed = 0.5f;
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
            //Debug.Log("callingSpawn. delay till next call:" + delay);
            GameObject NewChild = Instantiate(prefab, transform);
            MinionScript childScript = NewChild.GetComponent<MinionScript>();
            NewChild.tag = this.tag;
            for(int i = 0; i<level; i++) childScript.LevelUp();
            yield return new WaitForSeconds(delay);
        }
    }

    public void gainXP(int xpGained = 1)
    {
        while(Mathf.Pow(5f, level) <= (xp+= xpGained)) LevelUp();
    }

    public void LevelUp()
    {
        level++;
        xp -= (int) Mathf.Pow(5f, level);
        
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
        SceneManager.LoadScene("GameOver");

    }

}
