using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopItemScr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Tower selfTower;
    CellScr selfCell;
    public Image TowerLogo;
    public Text TowerName, TowerPrice;

    public Color BaseColor, CurrColor;

    public void SetStartData(Tower tower, CellScr cell)
    {
        selfTower = tower;
        //TowerLogo.sprite = tower.Spr;
        TowerName.text = tower.Name;
        TowerPrice.text = tower.Price.ToString();
        selfCell = cell;
    }

    public void  OnPointerEnter(PointerEventData eventData) //навер
    {
        //GetComponent<Image>().color = CurrColor;
    }

    public void OnPointerExit(PointerEventData eventData) //отвел
    {
        //GetComponent<Image>().color = BaseColor;
    }

    public void OnPointerClick(PointerEventData eventData) //нажал
    {
        if(MoneyManagerScr.Instance.GameMoney >= selfTower.Price)
        {
            selfCell.BuildTower(selfTower);
            MoneyManagerScr.Instance.GameMoney -= selfTower.Price;
        }
    }
}
