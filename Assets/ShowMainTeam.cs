using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;

public class ShowMainTeam : MonoBehaviour {


    public GameObject[] cardsMainTeam;
    public GameObject[] effects;
    void Start()
    {
        Global2 gl = new Global2();
        gl.cards = cardsMainTeam;
        gl.DeserilizeAndroid("currteam");

        gl.SetInf(cardsMainTeam,gl.People);
    
        if (effects.Length>0)
        for (int i = 0; i < cardsMainTeam.Length; i++)
        {
            cardsMainTeam[i].GetComponent<MainPlayer>().TurnEffects(effects[i]);
        }
    }
	

	void Update ()
    {
	
	}
}
