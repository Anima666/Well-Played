using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remove_at_btn : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
     public GameObject[] cards;
    public void remove()
    
    {
        cards = GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().cards;
        List<Player> pl = GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().array_player;
        string nickname = GetComponentInChildren<Text>().text;
        print("nickname " + nickname);
        for (int i = 0; i < cards.Length; i++)
        {
            if (nickname==cards[i].GetComponent<MainPlayer>().player.nickname)
                cards[i].GetComponent<Button>().enabled = true;
        }
        
        for (int i = 0; i < pl.Count; i++)
        {
            if (pl[i].nickname == nickname)
            {
               
                //GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>()
                GetComponentInChildren<Text>().text = "";
                GetComponent<Image>().color = Color.black;
                //    GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().count = int.Parse(this.name);

                GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().array_player.Remove(pl[i]);
                return;

            }
        }


    }
    public void SaveTeam()
    {
     
        List<Player> pl = GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().array_player;
        if (pl.Count == 5)
        {
            Global2 gl = new Global2();
            gl.SaveMyTeam("currteam", pl);
            Menu mn = new Menu();
            mn.OpenShop();
        }
    }
}
