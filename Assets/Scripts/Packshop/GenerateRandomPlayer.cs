using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEngine.Advertisements;

public class GenerateRandomPlayer : MonoBehaviour {


    public GameObject[] cards;
   // List<Player> People;
    MainPlayer[] mp= new MainPlayer[3];
    Global2 gl;
    public GameObject minus_txt;
    private Transform transform_mins_txt;
    void Start ()
    {
#if UNITY_EDITOR
        PlayerPrefs.SetInt("Diamond", 1000);

#endif
        if (minus_txt != null)
            transform_mins_txt = minus_txt.transform;
        gl = new Global2();
        gl.cards = cards;
        gl.Deserilize("persons");
        //Advertisement.Initialize("1388368",true);
        for (int i = 0; i < cards.Length; i++)
        {
            mp[i] = cards[i].GetComponentInChildren<MainPlayer>();
        }
        up_panel_getMoney = up_panel.GetComponent<GetMoney>();
    


    }

    public GameObject text;
    public GameObject up_panel;
    private GetMoney up_panel_getMoney;
    public void GetCards()
    {
        //if (Advertisement.IsReady())
        //{

        //    Advertisement.Show();
        //    if (Advertisement.isShowing)
        //        print("show");
        //}

        // print("lol "+PlayerPrefs.GetInt("Diamond"));
        int diamond = PlayerPrefs.GetInt("Diamond");
        if (diamond > Price)
        {
            up_panel_getMoney.RefreshMoney();
            PlayerPrefs.SetInt("Diamond", diamond - Price);

            text.SetActive(false);
            int chanceLeg;
            int chanceRare;
            int n = 0;


            // print("count  " + People.Count);

            List<Player> sort_people = new List<Player>(); ;
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetActive(true);
                GetChance(out chanceLeg, out chanceRare, out n, sort_people);

                mp[i].player = sort_people[Random.Range(0, sort_people.Count)];
                mp[i].sp = Resources.Load<Sprite>("Player/" + mp[i].player.nickname);
                if (mp[i].sp == null)
                    mp[i].sp = Resources.Load<Sprite>("no_imgPlayer.png");
                mp[i].Refesh();

            }
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


    // Update is called once per frame
    void Update ()
    {
       // print(transform_mins_txt.position.x);
	}
}
