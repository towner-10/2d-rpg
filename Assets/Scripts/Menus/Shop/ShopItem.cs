using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem {
	public string itemName;

	public enum itemType{ Sword, Shield, Potion, Bonus }
	public itemType itemTypeSelector;

	public Sprite itemImage;
	
}
