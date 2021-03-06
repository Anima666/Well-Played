﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {

	
	public void OpenMenu ()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
            SceneManager.LoadScene("MainScene");
        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
	}
    public void OpenMatch()
    {
        Global2 gl = new Global2();
        gl.DeserilizeAndroid("currteam");
        if (gl.People.Count == 5)
        {
            TetstClassic.lastscene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Match");
        }
        else
            print("ne 5");
    }
    public GameObject inputpanel;
    public void InputPanel()
    {

        inputpanel.SetActive(true);
    }
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
    }
    public MainPlayer mp;

    public void Buy()
    {
        
        int coins=PlayerPrefs.GetInt("Coins");
        if (coins >= mp.player.coast)
        {
            Player pl = mp.player;
            Global2 gl = new Global2();
            gl.DeserilizeAndroid("my_command");
            gl.People.Add(pl);
            gl.SaveMyTeam("my_command", gl.People);
            OpenShop();
            PlayerPrefs.SetInt("Coins", coins - mp.player.coast);
            GameObject.FindGameObjectWithTag("canvas").GetComponentInChildren<GetMoney>().RefreshMoney();
        }
    }
    public void OpenMain()
    {
        
        SceneManager.LoadScene("mainmenu");
        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
    }
    public void opnLanguageSetting()
    {
        SceneManager.LoadScene("changeLan");
    }
    public void BuyCase()
    {
        SceneManager.LoadScene("opencase");

        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public GameObject panel;
    public void OpenDonatPanel()
    {
        panel.SetActive(true);
    }
    public void CloseDonatPanel()
    {
        panel.SetActive(false);
    }
    public void GoLastScene()
    {
        if (TetstClassic.lastscene== "dataplayer")
        {
            OpenMain();
            return;
        }
        SceneManager.LoadScene(TetstClassic.lastscene);
    }
     public GameObject continue_btn;
     public void EnableContinuePanel()
    {
       if( PlayerPrefs.GetInt("continue")==1)
        {
            if (continue_btn != null)
            continue_btn.SetActive(true);
           // ""
        }

    } 
    Role_player nr = new Role_player();
    public void SetRole()
    {  
        nr.role = TetstClassic.Role[TetstClassic.count];
        nr.name = TetstClassic.last_nickname;
        TetstClassic.role_playes.Add(nr);
      
        TetstClassic.count++;
        SceneManager.LoadScene("setRole");

    }
    static bool Sort(string name)
    {
        switch(name)
        {
           case "mainmenu": return true;
           case "dataplayer": return true;
           case "opencase": return true;
           case "Shop": return true;
            case "Match": return false;
            default: return false;
        }
  
    }
    public static void OffUpPanel()
    {
       
        GameObject canvas = GameObject.FindGameObjectWithTag("canvas");       
        GameObject up_panel = canvas.transform.Find("UpPanel").gameObject;

       
        if (up_panel != null)
        {
            string name_scene = SceneManager.GetActiveScene().name;
            if (Sort(name_scene))
            {
                up_panel.SetActive(true);
            }
            else
            {
                up_panel.SetActive(false);
            }
        }
        
    }
    public void OpenSetRole()
    {
        TetstClassic.count = 0;
        SceneManager.LoadScene("setRole");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = ShowSimple };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    public void ShowRewardedAdWinPanel()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = RewaerWinPanel };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void RewaerWinPanel(ShowResult result)
    {
        if (result== ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") +200);
            GetComponent<GetMoney>().RefreshMoney();

        }
    }
    private void ShowSimple(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 5);
            GetComponent<GetMoney>().RefreshMoney();

        }
    }
    void Start()
    {
        EnableContinuePanel();
        Menu.OffUpPanel();
    }

}

