using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choice_hero : MonoBehaviour {

    // Use this for initialization
   // public GameObject global;
    public GameObject[] hero;
    int count = 0;
	void Start ()
    {
        img = GetComponent<SetRandomHero>().img1;
        //hero=global.GetComponent<noname>().hero;
        TetstClassic.last_btn = 0;
    }
    public GameObject btn_next;
    GameObject[] img;

    public void choice(int n) //оптимизировать
    {
       // btn_next.SetActive(true);
        for (int i = 0; i < hero.Length; i++)
        {
            if (hero[i].GetComponent<Button>().enabled == true)
            {
                hero[i].GetComponent<Image>().color = Color.white;
                hero[i].GetComponentInChildren<Text>().color = Color.black;
            }
           
        }
       hero[n].GetComponent<Image>().color = Color.green;
       hero[n].GetComponentInChildren<Text>().color = Color.white;
        img[n].GetComponent<moveheroes>().enabled = true;
       TetstClassic.last_btn = n;
       

    }
}
