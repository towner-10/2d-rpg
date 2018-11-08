using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [HideInInspector]public GameObject player = null;

    Quaternion rotation;

    private void Awake()
    {
        rotation = this.transform.rotation;
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
        GetComponent<Pathfinding.AIDestinationSetter>().target = player.transform;
        GetComponent<EnemyAttack>().player = player;
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
