using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerScr : MonoBehaviour
{

    public static MoneyManagerScr Instance;
    public Text MoneyTxt;
    public int GameMoney;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        MoneyTxt.text = GameMoney.ToString();
    }
}
