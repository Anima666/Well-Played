using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine.Advertisements;

public class GenerateRandomPlayer : MonoBehaviour {


    public GameObject[] cards;
    MainPlayer[] mp= new MainPlayer[3];
    Global2 gl;
    public GameObject btn_skip;
    void Start ()
    {
        #if UNITY_EDITOR
        PlayerPrefs.SetInt("Diamond", 1000);

        #endif

        gl = new Global2();
        gl.cards = cards;
        gl.Deserilize("persons");

        for (int i = 0; i < cards.Length; i++)
        {
            mp[i] = cards[i].GetComponentInChildren<MainPlayer>();
        }
        up_panel_getMoney = GameObject.FindGameObjectWithTag("canvas").GetComponentInChildren<GetMoney>();
        if (up_panel_getMoney != null)
            print("nenull");
    


    }

    public GameObject text;
    public GameObject up_panel;
    private GetMoney up_panel_getMoney;
    List<Player> vipadshii = new List<Player>();
    public GameObject btn_buy;
    public void GetCards()
    {

        int diamond = PlayerPrefs.GetInt("Diamond");
        if (diamond >= Price)
        {
           
            btn_skip.SetActive(true);
           
            PlayerPrefs.SetInt("Diamond", diamond - Price);
           // up_panel_getMoney.RefreshMoney();
            text.SetActive(false);
            int chanceLeg;
            int chanceRare;
            int n = 0;


            // print("count  " + People.Count);

            List<Player> sort_people = new List<Player>(); 
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetActive(true);
                GetChance(out chanceLeg, out chanceRare, out n, sort_people);
                int rd = Random.Range(0, sort_people.Count);
                sort_people.RemoveAt(rd);
                mp[i].player = sort_people[rd];
                vipadshii.Add(sort_people[rd]);
                mp[i].sp = Resources.Load<Sprite>("Player/" + mp[i].player.nickname);
                if (mp[i].sp == null)
                    mp[i].sp = Resources.Load<Sprite>("no_imgPlayer.png");
                mp[i].Refesh();

            }
            btn_buy.SetActive(false);
        }
        
        
    }

    private void GetChance(out int chanceLeg, out int chanceRare, out int n, List<Player> sort_people)
    {
        chanceLeg = Random.Range(0, 56);
        chanceRare = Random.Range(0, 20);
        if (chanceLeg == 1)
        {
            n = 2;
        }
        else
            if (chanceRare == 1)
        {
            n = 1;
        }
        else
        {
            n = 0;
        }

        for (int j2 = 0; j2 < gl.People.Count; j2++)
        {
            if (gl.People[j2].rarity == n)
                sort_people.Add(gl.People[j2]);
        }
    }

    public int Price;

    public void Skip()
    {
        btn_skip.SetActive(false);
        btn_buy.SetActive(true);
        text.SetActive(true);
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<test>().open = false;
            cards[i].SetActive(false);
            cards[i].transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        List<Player> pl = new List<Player>();
        Global2 gl = new Global2();
        gl.DeserilizeAndroid("my_command");
        gl.People.AddRange(vipadshii);
        gl.SaveMyTeam("my_command", gl.People);
    }

    
  
}
