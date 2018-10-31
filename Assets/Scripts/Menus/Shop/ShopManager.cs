using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour {

	public GameObject shopUI;
	public GameObject itemPrefab;
	bool enabled = false;

	void Start () {
		shopUI.SetActive(false);
	}

	private void Update() {
		if(enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                CloseUI();
            }
        }
	}
	

	public void ShowShopUI(ShopItem[] shopItems, string shopName){
		shopUI.SetActive(true);
		enabled = true;
		Time.timeScale = 0;
		shopUI.transform.Find("ShopName").gameObject.GetComponent<TextMeshProUGUI>().text = shopName;
		foreach(ShopItem si in shopItems){
			GameObject itemPrefabInstantiated = Instantiate(itemPrefab);
			itemPrefabInstantiated.transform.SetParent(shopUI.transform.Find("Grid"));
			itemPrefabInstantiated.transform.Find("Preview").gameObject.GetComponent<Image>().sprite = si.itemImage;
			Debug.Log(si.itemName);
		}
	}

	public void CloseUI(){
		Time.timeScale = 1;

		shopUI.transform.Find("ShopName").gameObject.GetComponent<TextMeshProUGUI>().text = null;
		foreach(Transform gm in shopUI.transform.Find("Grid")){
			Destroy(gm.gameObject);
		}

		enabled = false;
		shopUI.SetActive(false);
	}
}
