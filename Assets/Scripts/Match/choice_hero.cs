using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choice_hero : MonoBehaviour {

    public GameObject[] hero;
    int count = 0;
    int last_n=322;
    GameObject[] img;
    public GameObject[] place_on_minimap;
    public GameObject[] place_on_minimap_enemy;
    void Start ()
    {
       img = GetComponent<SetRandomHero>().img1;
      
        TetstClassic.last_btn = 0;
        for (int i = 0; i < img.Length; i++)
        {
            start_pos_img.Add(img[i].transform.position);
        }
       
    }
    public List<Vector3> start_pos_img = new List<Vector3>();
    public GameObject btn_next;
    
    public void choice(int n) //оптимизировать
    {
        if (last_n != n)
        {
            for (int i = 0; i < hero.Length; i++)
            {
                if (hero[i].GetComponent<Button>().enabled == true)
                {
                    if (img[i].GetComponent<CheckSet>().set != true)
                        img[i].transform.position = start_pos_img[i];
                    if (place_on_minimap[i].GetComponent<CheckSet>().set != true)
                        place_on_minimap[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hero_black");


                    hero[i].GetComponent<Image>().color = Color.white;
                    hero[i].GetComponentInChildren<Text>().color = Color.black;
                    img[i].GetComponent<moveheroes>().enabled = false;
                }
            }

            hero[n].GetComponent<Image>().color = new Color32(0,255,128,255);
            hero[n].GetComponentInChildren<Text>().color = Color.white;
            img[n].GetComponent<moveheroes>().enabled = true;
            TetstClassic.last_btn = n;
            last_n = n;
        }
       

    }
}
