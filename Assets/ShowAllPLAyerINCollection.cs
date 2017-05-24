using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAllPLAyerINCollection : MonoBehaviour {

    public GameObject[] cards;
    public GameObject shop;
    public GameObject my_col;
    public GameObject[] blackrect;
    int count = 0;
	public void ShowColl ()
    {
        my_col.SetActive(true);
        shop.SetActive(false);

        Global2 gl = new Global2();
        gl.DeserilizeAndroid("my_command");
        gl.SetInf(cards,gl.People);
        print("qweqwre "+gl.People.Count);
	}
    public void Ok()
    {
        if (array_player.Count==5)
        {
            Global2 gl = new Global2();
            gl.SaveMyTeam("currteam",array_player);
        }
    }
    public List<Player> array_player = new List<Player>();
    MainPlayer mp;
    public void Set(int n)
    {
        if (count <= 4)
        {
            mp = cards[n].GetComponent<MainPlayer>();
            array_player.Add(mp.player);
            print("press "+n);
            blackrect[count].GetComponentInChildren<Text>().text =mp.player.nickname;
            count++;
        }
    }
    
	
}
