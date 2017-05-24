using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remove_at_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	public void remove ()
    {
    List<Player> pl =GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().array_player;
     string nickname = GetComponentInChildren<Text>().text;
        print("nickname "+nickname);
        for (int i = 0; i < pl.Count; i++)
        {
            if (pl[i].nickname == nickname)
            {
                //GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>()
                GetComponentInChildren<Text>().text = "";
                GameObject.FindGameObjectWithTag("set_img").GetComponent<ShowAllPLAyerINCollection>().array_player.Remove(pl[i]);
                return;

            }
        }
       

    }
}
