using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;
    public Slider healthUI;

    private void Start()
    {
        healthUI.maxValue = health;
        healthUI.minValue = 0;
        healthUI.value = health;
    }

    public void Heal(int heal)
    {
        health += heal;
        healthUI.value = health;
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthUI.value = health;
    }
}
