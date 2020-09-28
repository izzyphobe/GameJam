using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    public Transform target;
    public float speed;
    public float maxhealth;
    public float health;
    public float bounce;
    MinionScript enemy;
    bool isInHand;

    public bool isInBattleGround;

    // Start is called before the first frame update
    void Start()
    {
        isInHand = false;
        health = maxhealth;
        isInBattleGround = false;
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        //initially - target = "battle area" in center
        
    }

    // Update is called once per frame
    void Update()
    { 
        //Attack target if target in range
    //Move to target if out of range and alive
    //Find new target (vector.movetowards)
    //Find target, move towards target
    //If someone attacks them or is within a certain range, that person becomes their target
    //If can't find minion to target, start attacking spawner
    //
        
    }

    void FixedUpdate(){
        if (isInHand)
        {
            FollowMouse();
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    void Attack(){

    }

    public void TogglePickup()
    {
        isInHand = !isInHand;
    }


    void FollowMouse()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos.z = transform.position.z;
        transform.position = MousePos;
    }


    //Move Minion twords targert if it exists
    // else aquire new target and move twords it
    void MoveTowardsTarget(){
        if(target == null)
            AquireTarget();
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    // Sets target to center of battleground if not in battleground
    // else to closest enemy
    public void AquireTarget(){
        //Debug.Log("getting new target");
        if(isInBattleGround){
            target = FindClosestEnemy().transform;
            //Debug.Log("Targeting nearest enemy");
        }
        else
            target = GameObject.Find("Battlefield").transform;
    }

    //FindClosestEnemy returns closest gameObject of opposing faction. Returns null if no targets
    // based on second example from https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    public GameObject FindClosestEnemy(){
        List<GameObject> gos = new List<GameObject>();
        if(!tag.Equals("Red")){
            gos.AddRange(GameObject.FindGameObjectsWithTag("Red"));
        }
        if(!tag.Equals("Blue")){
            gos.AddRange(GameObject.FindGameObjectsWithTag("Blue"));
        }
        if(!tag.Equals("Green")){
            gos.AddRange(GameObject.FindGameObjectsWithTag("Green"));
        }

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void SetTarget(GameObject t){ //change target to t

    }

    public void Hurt(int damage = 1){
        //Debug.Log(gameObject.tag + " minion hurt");
        health = health - damage;
        if(health <= 0)
            Die();
    }

    void Die(){
        //Debug.Log(gameObject.tag + " minion died");
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(!collision.gameObject.tag.Equals(tag)){
            //Debug.Log("colission between " + tag+ " and " + collision.gameObject.tag);
            enemy = collision.gameObject.GetComponent<MinionScript>();
            transform.position = Vector2.MoveTowards(transform.position, collision.gameObject.transform.position, -1*bounce);
            collision.gameObject.transform.position = Vector2.MoveTowards(collision.gameObject.transform.position, transform.position, -1*bounce);
            enemy.Hurt();
            this.Hurt();
        }
    }

}
