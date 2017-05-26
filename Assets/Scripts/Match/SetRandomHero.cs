using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SetRandomHero : MonoBehaviour {

    public GameObject[] img1;
    public GameObject[] img2;

    public  List<string> heroes = new List<string>();
    Color averageColour(Sprite sprite)
    {
        var croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);

        Color[] texColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                       (int)sprite.textureRect.y,
                                        (int)sprite.textureRect.width,
                                    (int)sprite.textureRect.height);
        //GetComponent<Image>().
        //Color32[] texColors = sprite.texture.GetPixels32();
        long total = texColors.Length;
        float r = 0; float g = 0; float b = 0;
        for (var i = 0; i < total; i++)
        {
            r += texColors[i].r;
            g += texColors[i].g;
            b += texColors[i].b;
        }
        float rt = (r / total);
        float gt = (g / total);
        float bt = (b / total);

        //print("total"+ total);
       // print("r" + rt);
        //print("g" + gt);
        //print("b" + bt);
        
        return new Color(rt, gt, bt, 255);
    }
    void Start()
    {
        RandomHero();

    }

    public void RandomHero()
    {
        string name_hero;
        Sprite sp;
        ReadHeroesName(heroes);
        GameObject[] btn_hero = GetComponent<choice_hero>().hero;
        for (int i = 0; i < 5; i++)
        {
            name_hero = heroes[UnityEngine.Random.Range(0, heroes.Count)];
            btn_hero[i].GetComponentInChildren<Text>().text = name_hero;
            sp = Resources.Load<Sprite>("heroes/" + name_hero);
            img1[i].GetComponent<Image>().sprite = sp;

            img1[i].name = name_hero;
            btn_hero[i].GetComponent<Image>().color = averageColour(img1[i].GetComponent<Image>().sprite);
            img2[i].GetComponent<Image>().sprite = sp;
        }
    }

    private static void ReadHeroesName(List<string> heroes)
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
