using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetRandomHero : MonoBehaviour {

    public GameObject[] img1;
    public GameObject[] img2;
    static  List<string> heroes = new List<string>();
    void Start()
    {
        // Menu.OffUpPanel();
        string name_hero;
        Sprite sp;
        ReadHeroesName();
        GameObject[] btn_hero = GetComponent<choice_hero>().hero;
        for (int i = 0; i < 5; i++)
        {
            name_hero = heroes[Random.Range(0, heroes.Count)];
            btn_hero[i].GetComponentInChildren<Text>().text = name_hero;
            sp= Resources.Load<Sprite>("heroes/" + name_hero);
            img1[i].GetComponent<Image>().sprite = sp;
            img1[i].name = name_hero;
            img2[i].GetComponent<Image>().sprite = sp;
        }

        
    }

    private static void ReadHeroesName()
    {
        TextAsset _xml = Resources.Load<TextAsset>("hero_name");
        using (StringReader reader = new StringReader(_xml.ToString()))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                //print(line);
                heroes.Add(line);
            }
        }
    }
}
