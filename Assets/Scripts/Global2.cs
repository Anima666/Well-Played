using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class Global2 : MonoBehaviour {


    public Country curr_lang = Country.ru;
    public GameObject[] cards;


    public List<Player> People;
    static XmlSerializer formatter = new XmlSerializer(typeof(List<Player>));

    void Start()
    {
        Deserilize("persons");
        GetPlayerFromCountry("Россия ");
       
    }
    
    public void GetPlayerFromCountry(string country)
    {
        List<Player> sort_people = new List<Player>();
        for (int i = 0; i < People.Count; i++)
        {
            if (People[i].country == country)
                sort_people.Add(People[i]);
        }

        print("count sort- " + sort_people.Count);
        SetInf(cards, sort_people);
        
    }

    public void SetInf(GameObject[] cards,List<Player> players)
    {
        MainPlayer mp;
        for (int i = 0; i < cards.Length; i++) 
        {
            cards[i].SetActive(false);
        }
        for (int i = 0; i < players.Count; i++) 
        {
            if (i < cards.Length)
            {
                cards[i].SetActive(true);
                mp = cards[i].GetComponent<MainPlayer>();

                mp.player = players[i];
                mp.sp = Resources.Load<Sprite>("Player/" + mp.player.nickname);
                if (mp.sp == null)
                    mp.sp = Resources.Load<Sprite>("no_imgPlayer.png");
                mp.Refesh();
            }
        } 
    }
    public void SetInfOneCard(GameObject card, Player player)
    {
        MainPlayer mp;
        
                mp = card.GetComponent<MainPlayer>();

                mp.player = player;
                mp.sp = Resources.Load<Sprite>("Player/" + mp.player.nickname);
                if (mp.sp == null)
                    mp.sp = Resources.Load<Sprite>("no_imgPlayer.png");
                mp.Refesh();
        
    }

    public  void SortRarity(int n)
    {
        List<Player> sort_people = new List<Player>();
        for (int i = 0; i < People.Count; i++)
        {
            if (People[i].rarity == n)
                sort_people.Add(People[i]);
        }
        SetInf(cards,sort_people);
        
    }

    public  void Deserilize(string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        StringReader reader = new StringReader(_xml.ToString());
        People = formatter.Deserialize(reader) as List<Player>;
        reader.Close();
    }
    public void SerilizeRole(string path, List<Role_player> rp)
    {
         XmlSerializer formatter = new XmlSerializer(typeof(List<Role_player>));
        using (FileStream fs = new FileStream(path+".xml", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, rp);
            print("Объект сериализован");
   
        }
    }

    void Update ()
    {
	
	}
}
