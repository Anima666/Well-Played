using UnityEngine;
using System.Collections;

public class AddPlayerInTeam : MonoBehaviour {

    // Use this for initialization
    public int count;
    public GameObject smt;
    public GameObject test;
    Player pl;
    Sprite sp;
	void Start ()
    {
        pl = test.GetComponent<MainPlayer>().player;
	}

    void OnMouseDown()
    {
        if (pl != null)
        {
            if (count < 5)
            {
                smt.GetComponent<ShowMainTeam>().cardsMainTeam[count].GetComponent<MainPlayer>().player = pl;
                smt.GetComponent<ShowMainTeam>().cardsMainTeam[count].GetComponent<MainPlayer>().sp = sp;
                smt.GetComponent<ShowMainTeam>().cardsMainTeam[count].GetComponent<MainPlayer>().Refesh();
                count++;
            }
         //   pl = null;
        }
    }
    void OnTriggerChetatM(Collider2D col)
    {
        pl = col.GetComponent<MainPlayer>().player;
        sp = col.GetComponent<MainPlayer>().sp;
    }
}
