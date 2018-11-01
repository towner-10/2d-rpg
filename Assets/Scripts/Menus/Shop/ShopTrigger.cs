using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour {

    public string shopName;
    public List<ShopItem> shopItems = new List<ShopItem>();
    public ShopManager sm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            sm.ShowShopUI(this, shopItems, shopName);
        }
    }
}