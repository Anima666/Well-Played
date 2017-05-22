using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_win : MonoBehaviour {

    public int win_cash;
    Menu menu = new Menu();
	 public void close_panel ()
    {
        
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + win_cash);
        menu.OpenMain();
        
    }
	
	void Start()
    {
     
    }
	public void GetDouble ()
    {
        menu.ShowRewardedAdWinPanel();
        menu.OpenMain();
    }
}
