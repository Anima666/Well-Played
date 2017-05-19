using UnityEngine;
using System.Collections;
[System.Serializable]
public class Player
{
    public string nickname;
    public string Fio;
    public string country;
    public int rarity = 3;
    public int coast = 100;
    public int soloMmr;
    public int carry;
    public int mid;
    public int offlane;
    public int support;

    public double kills_min;
    public double death_min;
    public double assist_min;

    public int GPM;
    public int XPM;

    public string[] signatures = new string[3];
    public Player()
    {

    }
}
    public class Player1 : MonoBehaviour {

        
    }

