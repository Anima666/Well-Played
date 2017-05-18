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
        //hero=global.GetComponent<noname>().hero;
        TetstClassic.last_btn = 0;
    }

    public void choice(int n) //оптимизировать
    {
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
        TetstClassic.last_btn = n;
        count++;

    }
}
