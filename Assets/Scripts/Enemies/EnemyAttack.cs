using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject player;

    public int damage = 20;

    bool canAttack = true;

	void Update () {
        if (GetComponent<Pathfinding.AIPath>().remainingDistance <= GetComponent<Pathfinding.AIPath>().endReachedDistance)
        {
            if (canAttack == true)
            {
                StartCoroutine(Attack());
            }
        }
	}

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.1f);
        if (GetComponent<Pathfinding.AIPath>().remainingDistance > GetComponent<Pathfinding.AIPath>().endReachedDistance)
        {
            canAttack = true;
            yield break;
        }
        player.GetComponent<PlayerHealth>().Damage(damage);
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
