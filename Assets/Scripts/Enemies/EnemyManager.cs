using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject player;

    Quaternion rotation;

    private void Start()
    {
        GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
        GetComponent<EnemyAttack>().player = player;
        rotation = this.transform.rotation;
    }

    void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            rotation.y -= 180;
        }

        if (player.transform.position.x < transform.position.x)
        {
            rotation.y = 0;
        }

        this.transform.rotation = rotation;
    }
}
