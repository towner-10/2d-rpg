using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {

    Quaternion rotation;

	void Start () {
        rotation = this.transform.rotation;
	}

	void Update () {
        this.transform.rotation = rotation;

    }
}
