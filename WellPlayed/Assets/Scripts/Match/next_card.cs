﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next_card : MonoBehaviour {

    // Use this for initialization
    public GameObject card;
    Global2 gl = new Global2();
    public GameObject global;
    private GameObject[] btn;
    void Start ()
    {
       
        btn = global.GetComponent<choice_hero>().hero ;
        TetstClassic.curr_cards = new int[5];
        gl.Deserilize("Currenteam");
        gl.SetInfOneCard(card, gl.People[0]);
    }

    int count = 1;
	public void Next ()
    {
        if (count==5)
        {
            CheckhWin();
            return;
        }
        btn[TetstClassic.last_btn].GetComponent<Image>().color = Color.grey;
        btn[TetstClassic.last_btn].GetComponent<Button>().enabled = false;
        gl.SetInfOneCard(card,gl.People[count]);
        //gl.SetInf(cardsMainTeam, gl.People);
        count++;
    }

    public void CheckhWin()
    {

        sr.Com_Deserilize("command");
        List<Player> pl = SearchCommand("natus_vincere");
        for (int i = 0; i < pl.Count; i++)
        {
            print(pl[i].nickname);
        }
        int count1 = 0;
        int count2 = 0;
        TestCheckMid(pl, ref count1, ref count2);

        //for (int i = 0; i < sr.command.Count; i++)
        //{
        //    for (int j = 0; j < sr.command[i].pl.Count; j++)
        //    {
        //        print(sr.command[i].pl[j].Fio);
        //    }

        //}


    }

    private void TestCheckMid(List<Player> pl, ref int count1, ref int count2)
    {
        int MaxMid = pl[0].mid; //поменять
        int MaxMid_Enemy = gl.People[0].mid; 
        for (int i = 0; i < pl.Count; i++)
        {
            if (pl[i].mid > MaxMid)
                MaxMid = pl[i].mid;
        }
        for (int i = 0; i < gl.People.Count; i++)
        {
            if (gl.People[i].mid > MaxMid_Enemy)
                MaxMid_Enemy = gl.People[i].mid;
        }
        if (MaxMid > MaxMid_Enemy)
            count1++;
        else
            count2++;
        //print("count1 "+count1);
        // print("count2 " + count2);
        //print("maxmid " + MaxMid);
        //print("MaxMid_Enemy " + MaxMid_Enemy);

    }
    private void TestChechStats(Player ally_pl, Player enemy_pl)
    {
        int count1_1 = 0;
        int count2_2 = 0;
        CheckBasicCharacter(ally_pl, enemy_pl, ref count1_1, ref count2_2);
        //сделать проверку если играет на своей сигнатурке, то сразу+10 (пример);
        //проверка соответсвует его установленная роль и там где он стоит и роль при рождении
        if (ally_pl.soloMmr > enemy_pl.soloMmr)
            count1_1++;
        else
            count2_2++;
     


     
    }

    private static void CheckBasicCharacter(Player ally_pl, Player enemy_pl, ref int count1_1, ref int count2_2)
    {
        if (ally_pl.assist_min > enemy_pl.assist_min)
            count1_1++;
        else
            count2_2++;

        if (ally_pl.death_min < enemy_pl.death_min)
            count1_1++;
        else
            count2_2++;

        if (ally_pl.kills_min > enemy_pl.kills_min)
            count1_1++;
        else
            count2_2++;

        if (ally_pl.XPM > enemy_pl.XPM)
            count1_1++;
        else
            count2_2++;

        if (ally_pl.GPM > enemy_pl.GPM)
            count1_1++;
        else
            count2_2++;

    }

    Ser_Command sr = new Ser_Command();
    List<Player> SearchCommand(string name)
    {
        for (int i = 0; i < sr.command.Count; i++)
        {
            if (sr.command[i].name == name)
            {
                return sr.command[i].pl;
            }
          
        }
        return null ;
    }
}
