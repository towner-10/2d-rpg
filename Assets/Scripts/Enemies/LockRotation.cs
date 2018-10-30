using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {

    Quaternion rotation;
    public Transform player;

	void Start () {
        rotation = this.transform.rotation;
	}

	void Update () {
        if(player.position.x > transform.position.x)
        {
            rotation.y -= 180;
        }

        if(player.position.x < transform.position.x)
        {
            rotation.y = 0;
        }

        this.transform.rotation = rotation;
    }
}
