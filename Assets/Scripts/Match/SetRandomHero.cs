using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetRandomHero : MonoBehaviour {

    GameObject hero_up;
    static  List<string> heroes = new List<string>();
    void Start()
    {
        // Menu.OffUpPanel();
        ReadHeroesName();
        for (int i = 0; i < 5; i++)
        {
            print(heroes[Random.Range(0,heroes.Count)]);
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
