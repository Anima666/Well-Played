using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ShowAllPLAyerINCollection : MonoBehaviour {

    public GameObject[] cards;
    public GameObject shop;
    public GameObject my_col;
    public GameObject[] blackrect;
    public int count = 0;

    public void backpage()
    {
        int count = 0;
        if (cout_page - 1 >= 0)
        {
            print("count "+cout_page);
            cout_page--;
            for (int i = cout_page * cards.Length; i < gl.People.Count; i++)
            {
                if (count < cards.Length)
                {
                    pl.Insert(0,gl.People[i]);
                    count++;
                }
            }
        }
        gl.SetInf(cards, pl);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Button>().enabled = true;
            for (int j = 0; j < blackrect.Length; j++)
            {
                if (cards[i].GetComponent<MainPlayer>().player.nickname == blackrect[j].GetComponentInChildren<Text>().text)
                    cards[i].GetComponent<Button>().enabled = false;
            }
        }

    }
     public int cout_page = 0;
     public List<Player> pl = new List<Player>();

    public void nextpage()
    {
        //pl = new List<Player>();
       
        //pl = gl.People;
        print("svatoiDux");
        

        pl.RemoveRange(0, cards.Length);
        gl.SetInf(cards,pl);
        cout_page++;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<Button>().enabled = true;
            for (int j = 0; j < blackrect.Length; j++)
            {
                if (cards[i].GetComponent<MainPlayer>().player.nickname == blackrect[j].GetComponentInChildren<Text>().text)
                    cards[i].GetComponent<Button>().enabled = false;
            }
        }
    }
    Global2 gl = new Global2();

	public void ShowColl ()
    {
        my_col.SetActive(true);
        shop.SetActive(false);

        
        gl.DeserilizeAndroid("my_command");
        
        print("qweqwre "+gl.People.Count);
        var list = gl.People.OrderByDescending(x=>x.rarity).ToList();
        gl.People = list;
        gl.SetInf(cards,gl.People);
     
        
        for (int i = 0; i < gl.People.Count; i++)
        {
            pl.Add(gl.People[i]);
        }
    }
    public void ReverseShowColl()
    {
       
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
            for (int i = 0; i < 5; i++)
            {
                if (blackrect[i].GetComponentInChildren<Text>().text == "")
                {
                    mp = cards[n].GetComponent<MainPlayer>();
                    array_player.Add(mp.player);
                    print("press " + n);
                    blackrect[i].GetComponentInChildren<Text>().text = mp.player.nickname;
                    blackrect[i].GetComponent<Image>().color = cards[n].GetComponent<MainPlayer>().CheckRar();
                    cards[n].GetComponent<Button>().enabled = false;
                    //count++;
                    return;
                }
            }
           
        }
    }
    void Start()
    {
       // ShowColl();
        
    }
	
}
