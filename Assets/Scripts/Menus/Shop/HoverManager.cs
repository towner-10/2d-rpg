using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class HoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method.
{
    ShopManager shopManager;
    ShopItem shopItem;

    public void GetStats(ShopManager sm, ShopItem si)
    {
        shopManager = sm;
        shopItem = si;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        shopManager.hovering = true;
        shopManager.SetHoverStats(shopItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shopManager.hovering = false;
        shopManager.ClearHoverStats();
    }
}