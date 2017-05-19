using UnityEngine;
using System.Collections;

public class SetMoney : MonoBehaviour {

    public int coins;
    public int diamond;
    void Start()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Diamond", diamond);
    }
}
