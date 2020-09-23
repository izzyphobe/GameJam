using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Battlefield").transform;
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
        //move toward target
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void Attack(){

    }

    void SetTarget(GameObject t){ //change target to t

    }
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("colission");
        if(!collision.gameObject.tag.Equals(tag)){
            Debug.Log("colission between " + tag+ "and " + collision.gameObject.tag);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
