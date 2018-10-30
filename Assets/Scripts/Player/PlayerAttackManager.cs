using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour {

    public enum AttackDirection { Up, Down, Left, Right }
    public AttackDirection attackDirection;

    private PlayerController pc;
    private GameObject[] attackColliders;

    void Start () {
        pc = this.transform.GetComponentInParent<PlayerController>();
        InitColliders();
	}
	
	void Update () {
        if(pc.attacking == false)
        {
            if (pc.direction.x >= 5)
            {
                attackDirection = AttackDirection.Up;
                DisableColliders();
            }
            else if (pc.direction.x <= -5)
            {
                attackDirection = AttackDirection.Down;
                DisableColliders();
            }
            else if (pc.direction.y <= -5)
            {
                attackDirection = AttackDirection.Left;
                DisableColliders();
            }
            else if (pc.direction.y >= 5)
            {
                attackDirection = AttackDirection.Right;
                DisableColliders();
            }
        }
    }

    void InitColliders()
    {
        attackColliders = new GameObject[4];
        attackColliders[0] = this.transform.GetChild(0).gameObject;
        attackColliders[1] = this.transform.GetChild(1).gameObject;
        attackColliders[2] = this.transform.GetChild(2).gameObject;
        attackColliders[3] = this.transform.GetChild(3).gameObject;

        foreach (GameObject collider in attackColliders)
        {
            Debug.Log(collider.name);
            collider.SetActive(false);
        }
    }

    void DisableColliders()
    {
        if(attackDirection == AttackDirection.Up)
        {
            attackColliders[0].SetActive(true);
            attackColliders[1].SetActive(false);
            attackColliders[2].SetActive(false);
            attackColliders[3].SetActive(false);
        }
        else if(attackDirection == AttackDirection.Down)
        {
            attackColliders[0].SetActive(false);
            attackColliders[1].SetActive(true);
            attackColliders[2].SetActive(false);
            attackColliders[3].SetActive(false);
        }
        else if (attackDirection == AttackDirection.Left)
        {
            attackColliders[0].SetActive(false);
            attackColliders[1].SetActive(false);
            attackColliders[2].SetActive(true);
            attackColliders[3].SetActive(false);
        }
        else if (attackDirection == AttackDirection.Right)
        {
            attackColliders[0].SetActive(false);
            attackColliders[1].SetActive(false);
            attackColliders[2].SetActive(false);
            attackColliders[3].SetActive(true);
        }
    }
}
