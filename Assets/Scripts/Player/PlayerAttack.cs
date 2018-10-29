using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject player;
    private int attackCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.GetComponent<PlayerController>().attacking == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (attackCount >= 1)
                    return;

                attackCount++;
                Damage(other.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player.GetComponent<PlayerController>().attacking == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (attackCount >= 1)
                    return;

                attackCount++;
                Damage(other.gameObject);
            }
        }
    }
    
    void Damage(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().Damage(50, player.GetComponent<PlayerController>());
    }

    private void Update()
    {
        if(player.GetComponent<PlayerController>().attacking == false)
        {
            attackCount = 0;
        }
    }
}
