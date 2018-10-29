using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 100;

    private void Update()
    {
        if (health <= 0) {
            Die();
        }
    }

    public void Damage(int damage, PlayerController pc)
    { 
        health -= damage;
        StartCoroutine(DamageEffects(pc));
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    IEnumerator DamageEffects(PlayerController pc)
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = pc.direction * 2;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
