using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelTacticCards : MonoBehaviour {

	
	public void Cancel ()
    {
        Menu menu = new Menu();
        TetstClassic.count = 0;
        TetstClassic.curr_cards = new int[5];
        TetstClassic.Role = new string[5];
        PlayerPrefs.SetString("setrole", "begin");
        menu.SetRole();
    }
}
