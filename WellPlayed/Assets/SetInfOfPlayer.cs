using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetInfOfPlayer : MonoBehaviour {

    public GameObject btn_ok;
    public GameObject btn_buy;

    public Text Fio;
    public Text Solommr;
    public Text Price;

    public GameObject carry;
    public GameObject mid;
    public GameObject offlane;
    public GameObject supp;

    public GameObject xpm;
    public GameObject gpm;

    public GameObject kills;
    public GameObject death;
    public GameObject assist;

    public GameObject card;
    public GameObject[] signature;
    void Start ()  
    {
        if (TetstClassic.lastscene == "mainmenu")
        {
            btn_buy.SetActive(false);
            btn_ok.SetActive(false);
        }
        if (TetstClassic.lastscene == "setRole")
        {
            btn_buy.SetActive(false);
            //btn_ok.SetActive(false);
        }

        MainPlayer mp = card.GetComponent<MainPlayer>();
        mp.player = TetstClassic.pl;
        mp.sp = TetstClassic.spite;
        mp.Refesh();
        Fio.text = mp.player.Fio;
        Solommr.text += " "+mp.player.soloMmr.ToString();
        Price.text += " "+mp.player.coast.ToString() ;
       // GameObject[] signature = GameObject.FindGameObjectsWithTag("signature");
        Sprite sprite_hero;
        for (int i = 0; i < 3; i++)
        {
            sprite_hero= Resources.Load<Sprite>("heroes/" + mp.player.signatures[i]);
            if (sprite_hero == null)
                sprite_hero = Resources.Load<Sprite>("no_img");

            signature[i].GetComponentInChildren<SpriteRenderer>().sprite = sprite_hero;
        }

        
        Method2(xpm,mp.player.XPM);
        Method2(gpm, mp.player.GPM);

        Method1(carry,mp.player.carry);
        Method1(mid, mp.player.mid);
        Method1(offlane, mp.player.offlane);
        Method1(supp, mp.player.support);

        Method3(kills, mp.player.kills_min);
        Method3(death, mp.player.death_min);
        Method3(assist, mp.player.assist_min);

    }

    private static void Method1(GameObject test, int n)
    {
        test.GetComponent<TextMesh>().text += " " + n.ToString();
        if (n <= 50)
            test.GetComponent<Image>().color = Color.red;
    }
    private static void Method2(GameObject test, int n)
    {
        test.GetComponent<TextMesh>().text += " " + n.ToString();
        if (n <= 500)
            test.GetComponent<Image>().color = Color.red;
    }
    private static void Method3(GameObject test, double n)
    {
        test.GetComponent<TextMesh>().text += " " + n.ToString();
 
            //test.GetComponent<Image>().color = Color.red;
    }


}
