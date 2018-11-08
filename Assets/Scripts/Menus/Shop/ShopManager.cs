using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour {

	public GameObject shopUI;
    public GameObject hoverUI;
	public GameObject itemPrefab;

    public bool hovering = false;

    ShopTrigger trigger;
	bool shopEnabled = false;

    List<GameObject> currentObjectsOnDisplay = new List<GameObject>();

	void Start () {
		shopUI.SetActive(false);
        hoverUI.SetActive(false);
	}

	private void Update() {
        hoverUI.transform.position = new Vector2(Input.mousePosition.x + 100, Input.mousePosition.y - 80);

        hoverUI.SetActive(hovering);

        if (shopEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                CloseUI();
            }
        }
	}
	
    public void SetHoverStats(ShopItem si)
    {
        hoverUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = si.itemName;
        hoverUI.transform.Find("ItemType").GetComponent<TextMeshProUGUI>().text = "Type: " + si.itemTypeSelector.ToString();
        hoverUI.transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>().text = "$" + si.itemPrice.ToString();
    }

    public void ClearHoverStats()
    {
        hoverUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = null;
        hoverUI.transform.Find("ItemType").GetComponent<TextMeshProUGUI>().text = null;
        hoverUI.transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>().text = null;
    }

	public void ShowShopUI(ShopTrigger st, List<ShopItem> shopItems, string shopName){
        trigger = st;
		shopUI.SetActive(true);
		shopEnabled = true;
		Time.timeScale = 0;
		shopUI.transform.Find("ShopName").gameObject.GetComponent<TextMeshProUGUI>().text = shopName;

		foreach(ShopItem si in shopItems){
			GameObject itemPrefabInstantiated = Instantiate(itemPrefab);
            currentObjectsOnDisplay.Add(itemPrefabInstantiated);
            itemPrefabInstantiated.GetComponent<HoverManager>().GetStats(this, si);
            itemPrefabInstantiated.GetComponent<Button>().onClick.AddListener(() => PurchaseItem(itemPrefabInstantiated, si));
            itemPrefabInstantiated.transform.SetParent(shopUI.transform.Find("Grid"));
			itemPrefabInstantiated.transform.Find("Preview").gameObject.GetComponent<Image>().sprite = si.itemImage;
		}
	}

    public void PurchaseItem(GameObject ui, ShopItem item)
    {
        hovering = false;
        currentObjectsOnDisplay.Remove(ui);
        trigger.shopItems.Remove(item);
        Destroy(ui);

        if (currentObjectsOnDisplay.Count == 0)
        {
            CloseUI();
        }
    }

	public void CloseUI(){
		Time.timeScale = 1;

		shopUI.transform.Find("ShopName").gameObject.GetComponent<TextMeshProUGUI>().text = null;
		foreach(Transform gm in shopUI.transform.Find("Grid")){
			Destroy(gm.gameObject);
		}

		shopEnabled = false;
		shopUI.SetActive(false);
	}
}
