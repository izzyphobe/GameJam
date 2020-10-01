using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlegroundScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Red") || collision.gameObject.tag.Equals("Blue") || collision.gameObject.tag.Equals("Green")){
            //Debug.Log("colission between " + tag+ " and " + collision.gameObject.tag);
            MinionScript minion = collision.gameObject.GetComponent<MinionScript>();
            minion.isInBattleGround = true;
            minion.AquireTarget();
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        /*if(collision.gameObject.tag.Equals("Red") || collision.gameObject.tag.Equals("Blue") || collision.gameObject.tag.Equals("Green")){
            //Debug.Log("colission between " + tag+ " and " + collision.gameObject.tag);
            MinionScript minion = collision.gameObject.GetComponent<MinionScript>();
            minion.isInBattleGround = false;
            
        }*/
    }
}
