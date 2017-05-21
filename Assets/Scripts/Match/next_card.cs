using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class next_card : MonoBehaviour {

    // Use this for initialization
    public GameObject card;
    Global2 gl = new Global2();
    public GameObject global;
    private GameObject[] btn;
    GameObject[] place_on_minimap_ally;
    void Start ()
    {
        btn = global.GetComponent<choice_hero>().hero ;
        TetstClassic.curr_cards = new int[5];
        gl.Deserilize("Currenteam");
        gl.SetInfOneCard(card, gl.People[0]);

        img1 = GetComponent<SetRandomHero>().img1;
       // place_on_minimap = GameObject.FindGameObjectsWithTag("set_img");
        img2 = GetComponent<SetRandomHero>().img2;
        place_on_minimap_ally = GetComponent<choice_hero>().place_on_minimap;
        for (int q = 0; q < 4; q++)
        {
            array[q] = new array_role_check();
        }
    }

    int count = 1;
    GameObject[] img1;
    GameObject[] img2;
    public GameObject btn_next;
    int last_btn = 0;
	public void Next ()
    {
        //count = 5;

        btn_next.SetActive(false);
        if (count == 5)
        {
            
            CheckhWin();
            return;
        }
        SetBtnAndImage();
        count++;
    }

    private void SetBtnAndImage()
    {
        last_btn = TetstClassic.last_btn;
        btn[last_btn].GetComponent<Image>().color = Color.grey;
        btn[last_btn].GetComponent<Button>().enabled = false;
        gl.SetInfOneCard(card, gl.People[count]);

        img2[last_btn].GetComponent<Image>().color = Color.grey;
        img1[last_btn].GetComponent<CheckSet>().set = true;
        img1[last_btn].GetComponent<moveheroes>().enabled = false;
        img1[last_btn].GetComponent<Button>().enabled = false;
        for (int i = 0; i < place_on_minimap_ally.Length; i++)
        {
            if (place_on_minimap_ally[i].GetComponent<SpriteRenderer>().sprite.name != "hero_black")
                place_on_minimap_ally[i].GetComponent<CheckSet>().set = true;
        }
    }

    public void CheckhWin()
    {

        sr.Com_Deserilize("command");
        Command cm_enemy = new Command();
        cm_enemy =SearchCommand("natus_vincere");

        Command my_cm = new Command();
        my_cm.pl = gl.People;

        int points_one = GetPointFromTeam(my_cm);
        int points_two = GetPointFromTeam(cm_enemy);
        // for (int i = 0; i < 5; i++)
        // {
        print(SearchPlayer(my_cm, "support"));
        print(SearchPlayer(cm_enemy, "support"));

        //CheckBasicCharacter(SearchPlayer(my_cm,"carry"), SearchPlayer(cm_enemy, "carry"), ref points_one, ref points_two); //нужно сравнивать по ролям (mid||mid)
        //print("role "+my_cm.pl[i].Role);
        //CheckBasicCharacter(SearchPlayer(my_cm, "mid"), SearchPlayer(cm_enemy, "mid"), ref points_one, ref points_two);
        //CheckBasicCharacter(SearchPlayer(my_cm, "support"), SearchPlayer(cm_enemy, "support"), ref points_one, ref points_two);
        //CheckBasicCharacter(SearchPlayer(my_cm, "offlane"), SearchPlayer(cm_enemy, "offlane"), ref points_one, ref points_two);
        //}
        print("point A "+ points_one);
        print("point B " + points_two);



    }

    double SearchPlayer(Command cm,string role)
    {
        double count = 0;
        var playeer = cm.pl.Where(x => x.Role == role);
        foreach (Player item in playeer)
        {
            count+= item.XPM + item.GPM + item.kills_min + item.assist_min - item.death_min;
        }

       return count;
  
    }

    private static void CheckBasicCharacter(Player ally_pl, Player enemy_pl, ref int count1_1, ref int count2_2)
    {
        if (ally_pl != null & enemy_pl != null)
        {
            if (ally_pl.soloMmr != enemy_pl.soloMmr)
            {
                if (ally_pl.soloMmr > enemy_pl.soloMmr)
                    count1_1++;
                else
                    count2_2++;
            }
            if (ally_pl.assist_min != enemy_pl.assist_min)
            {
                if (ally_pl.assist_min > enemy_pl.assist_min)
                    count1_1++;
                else
                    count2_2++;
            }

            if (ally_pl.death_min != enemy_pl.death_min)
            {
                if (ally_pl.death_min < enemy_pl.death_min)
                    count1_1++;
                else
                    count2_2++;
            }

            if (ally_pl.kills_min != enemy_pl.kills_min)
            {
                if (ally_pl.kills_min > enemy_pl.kills_min)
                    count1_1++;
                else
                    count2_2++;
            }
            if (ally_pl.XPM != enemy_pl.XPM)
            {
                if (ally_pl.XPM > enemy_pl.XPM)
                    count1_1++;
                else
                    count2_2++;
            }
            if (ally_pl.GPM != enemy_pl.GPM)
            {
                if (ally_pl.GPM > enemy_pl.GPM)
                    count1_1++;
                else
                    count2_2++;
            }
        }
    }
    array_role_check[] array = new array_role_check[4];
    CheckSet ch = new CheckSet();
    Ser_Command sr = new Ser_Command();

    int GetPointFromTeam(Command comand) //for enemy dont work
    {
        int count = 0;
        int role_count = 0;
     
        string role;

        for (int i = 0; i < comand.pl.Count; i++)
        {
            role = SetValueAndRole(comand, i);
            comand.pl[i].Role = role;

            for (int k = 0; k < 5; k++)
            {
                ch = place_on_minimap_ally[k].GetComponent<CheckSet>();             
                if (comand.pl[i].nickname == ch.nickame) 
                {
                    if (role == ch.role)
                        role_count++;
                    count = CheckSignatures(comand, count, i);
                }
            }
        }
      //  print("ccount "+ role_count);
        return count + role_count;
    }

    private int CheckSignatures(Command comand, int count, int i)
    {
        for (int j = 0; j < comand.pl[i].signatures.Length; j++)
        {
            if (comand.pl[i].signatures[j] == ch.hero)
                count++;
        }

        return count;
    }

    private string SetValueAndRole(Command comand, int i)
    {
        string role;
        array[0].value = comand.pl[i].mid;
        array[0].role = "mid";

        array[1].value = comand.pl[i].carry;
        array[1].role = "carry";

        array[2].value = comand.pl[i].offlane;
        array[2].role = "offlane";

        array[3].value = comand.pl[i].support;
        array[3].role = "support";

        int[] values = new int[4];
        for (int q = 0; q < 4; q++)
        {
            values[q] = new int();
            values[q] = array[q].value;

        }
        int max = array.Max(x => x.value);
        int n = Array.IndexOf(values, max);
        role = array[n].role;
        return role;
    }

    
    Command SearchCommand(string name_team)
    {
        string[] lel = { "12", "213" };
        var cm = sr.command.Where(x => x.name == name_team).Select(x=>x).First() ;
        return cm ;
    }
}
