using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScr : MonoBehaviour
{
    public bool isGround, hasTower = false;

    public Color BaseColor, CurrColor;

    public GameObject ShopPref, TowerPref;

    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<ShopScr>().Length == 0)
            GetComponent<SpriteRenderer>().color = CurrColor;

    }

    private void OnMouseExit() 
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    private void OnMouseDown()
    {
        if(!isGround && FindObjectsOfType<ShopScr>().Length == 0)
            if(!hasTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<ShopScr>().selfCell = this;
            }
    }

    public void BuildTower(Tower tower)
    {
        GameObject tmpTower = Instantiate(TowerPref);
        tmpTower.transform.SetParent(transform, false);
        Vector2 towerPos = new Vector2(transform.position.x + tmpTower.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                       transform.position.y - tmpTower.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        tmpTower.transform.position = towerPos;
        tmpTower.GetComponent<TowerScr>().selfType = (TowerType)tower.type;

        hasTower = true;
        FindObjectOfType<ShopScr>().CloseShop();
    }
}
