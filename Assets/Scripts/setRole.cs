using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setRole : MonoBehaviour {

    // Use this for initialization
    public GameObject[] cards;
    public Sprite[] sprite;
    public GameObject img_role;
    private Menu menu;
    
    void Awake()
    {
        menu = new Menu();
    }
    public GameObject btn_cancel;
    void Start()
    {
        PullDataCards();
        if (PlayerPrefs.GetString("setrole") == "end")
        {
            btn_cancel.SetActive(true);
           
            img_role.SetActive(false);
        }
        else
        {
            int count = TetstClassic.count;
            if (count == 5)
            {
                menu.OpenMain();
                PlayerPrefs.SetString("setrole", "end");
                return;
            }


            // if (PlayerPrefs.GetString("setrole")=="begin")
            for (int i = 0; i < cards.Length; i++)
            {
                cards[TetstClassic.curr_cards[i]].SetActive(false);
            }
            img_role.GetComponent<Image>().sprite = sprite[count];


        }
    }

    private void PullDataCards()
    {
        Global2 gl = new Global2();
        gl.cards = cards;
        gl.Deserilize("Currenteam");

        gl.SetInf(cards, gl.People);
    }

    void Press()
    {
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
