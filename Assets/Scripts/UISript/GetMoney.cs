using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour {

    public Text coins;
    public Text diamond;
    void Awake() //Поменять
    {
        RefreshMoney();
    }
    

    public void RefreshMoney()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
        diamond.text = PlayerPrefs.GetInt("Diamond").ToString();
    }
}
