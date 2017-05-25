using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class next_card : MonoBehaviour {

    public GameObject panel_result;
    public GameObject card;
    Global2 gl = new Global2();
    public GameObject global;
    private GameObject[] btn;
    private GameObject[] hero_enemy_onminimap;
    GameObject[] place_on_minimap_ally;
    void Start ()
    {
        btn = global.GetComponent<choice_hero>().hero ;
        TetstClassic.curr_cards = new int[5];
        gl.DeserilizeAndroid("currteam");
        gl.SetInfOneCard(card, gl.People[0]);
        Sprite sp;
       /// image_team[0].GetComponent<Image>().color = Color.green;
        for (int i = 0; i < 5; i++)
        {
            sp = Resources.Load<Sprite>("Player/" + gl.People[i].nickname);
            if (sp == null)
                sp = Resources.Load<Sprite>("no_imgPlayer.png");
            image_team[i].GetComponent<Image>().sprite = sp;
                }
       

        img1 = GetComponent<SetRandomHero>().img1;

        //img2 = img1.Clone;
        img2 = GetComponent<SetRandomHero>().img2;
        place_on_minimap_ally = GetComponent<choice_hero>().place_on_minimap;
        hero_enemy_onminimap = GetComponent<choice_hero>().place_on_minimap_enemy;
        for (int q = 0; q < 4; q++)
        {
            array[q] = new array_role_check();
            
        }
        hero_roles[0]= "mid";
        hero_roles[1] = "carry";
        hero_roles[2] = "offlane";
        hero_roles[3] = "support";

        sr.Com_Deserilize("command");
        cm_enemy = SearchCommand("natus_vincere");

        for (int i = 0; i < cm_enemy.pl.Count; i++)
        {
            cm_enemy.pl[i].Role = SetValueAndRole(cm_enemy, i);
        }

        int count = 0;
        int count_2 = 0;
        for (int i = 0; i < signatures_player.Length; i++)
        {
            if (count == 3)
                count = 0;           
                signatures_player[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("heroes/"+gl.People[count_2/3].signatures[count]);
            count++;
            count_2++;
        }
        SetEnemyTeamOnMinimap();

    }

    int count = 1;
    GameObject[] img1;
    GameObject[] img2;
    public GameObject btn_next;
    int last_btn = 0;
    public GameObject[] image_team;
    public GameObject[] signatures_player;
    public void Next ()
    {
        //count = 5;

        btn_next.SetActive(false);
        
        
       // image_team[count].GetComponent<Image>().color = Color.green;
        
        if (count == 5)
        {
            CheckhWin();
            return;
        }
        SetBtnAndImage();
        count++;
        
    }

    private void SetEnemyTeamOnMinimap()
    {
        List<string> heroes = GetComponent<SetRandomHero>().heroes;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (hero_enemy_onminimap[i].name == cm_enemy.pl[j].Role)
                {
                    string name_hero = heroes[UnityEngine.Random.Range(0, heroes.Count)];
                    CheckSet ch = hero_enemy_onminimap[i].GetComponent<CheckSet>();
                    ch.nickame = cm_enemy.pl[i].nickname;
                    ch.hero = name_hero;
                    ch.role = cm_enemy.pl[j].Role;
                    hero_enemy_onminimap[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("heroes/" + name_hero);

                }
            }
        }
    }

    Command cm_enemy = new Command();
    string[] hero_roles = new string[4];
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

        Command my_cm = new Command();
        my_cm.pl = gl.People;

        int points_one = GetPointFromTeam_ally(my_cm);
        int points_two = GetPointFromTeam_enemy(cm_enemy);
        for (int i = 0; i < hero_roles.Length; i++)
        {
            if (SearchPlayer(my_cm, hero_roles[i]) > SearchPlayer(cm_enemy, hero_roles[i]))
                points_one++;
            else
                points_two++;
        }
        Text text = panel_result.GetComponentInChildren<Text>();
        panel_result.SetActive(true);
        if (points_one > points_two)
            text.text = "You Win";
        else if (points_one < points_two)
        {
            text.text = "You Lose (";
        }
        else
        {
            text.text = "Ничья";
        }

            print("point A "+ points_one);
        print("point B " + points_two);



    }

    double SearchPlayer(Command cm,string role)
    {
        double point = 0;
        int count = 0;
        var playeer = cm.pl.Where(x => x.Role == role);
        foreach (Player item in playeer)
        {
            point+= item.XPM + item.GPM + item.kills_min + item.assist_min - item.death_min;
            count++;
         //   print("item "+item.nickname);
        }
        print("role - "+ role +" "+ point / count);
       return point/count;
  
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

    int GetPointFromTeam_ally(Command comand) 
    {
        int count = 0;
        int role_count = 0;
     
        string role;

        for (int i = 0; i < comand.pl.Count; i++)
        {
            role = SetValueAndRole(comand, i);
            

            for (int k = 0; k < 5; k++)
            {
                ch = place_on_minimap_ally[k].GetComponent<CheckSet>();
                
                if (comand.pl[i].nickname == ch.nickame) 
                {
                    comand.pl[i].Role = ch.role;       
                    if (role == ch.role)
                        role_count++;
                  
                   count = CheckSignatures(comand, count, i);
                }
            }
        }
      //  print("ccount "+ role_count);
        return count + role_count;
    }
    int GetPointFromTeam_enemy(Command comand)
    {
        int count = 0;
        int role_count = 0;

        string role;

        for (int i = 0; i < comand.pl.Count; i++)
        {
            role = SetValueAndRole(comand, i);


            for (int k = 0; k < 5; k++)
            {
                ch = hero_enemy_onminimap[k].GetComponent<CheckSet>();

                if (comand.pl[i].nickname == ch.nickame)
                {
                    comand.pl[i].Role = ch.role;
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
       
        var cm = sr.command.Where(x => x.name == name_team).Select(x=>x).First() ;
        return cm ;
    }
}
