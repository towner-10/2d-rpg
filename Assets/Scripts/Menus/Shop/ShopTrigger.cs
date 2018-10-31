using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour {

    public string shopName;
    public ShopItem[] shopItems;
    public ShopManager sm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            sm.ShowShopUI(shopItems, shopName);
        }
    }
}