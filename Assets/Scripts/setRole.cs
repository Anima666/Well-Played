using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setRole : MonoBehaviour {

    // Use this for initialization
    public GameObject[] cards;
    public Sprite[] hero_sprite;
    public GameObject img_role;
    private Menu menu;
    
    void Awake()
    {
        menu = new Menu();
    }
    public GameObject btn_cancel;
    void Start()
    {
#if UNITY_EDITOR
        PlayerPrefs.SetString("setrole", "begin");
#endif

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
                Global2 gl = new Global2();
                gl.SerilizeRole("test_role", TetstClassic.role_playes);
                PlayerPrefs.SetString("setrole", "end");
                return;
            }

            img_role.GetComponent<Image>().sprite = hero_sprite[count];
            for (int i = 0; i < TetstClassic.Role.Length; i++)
            {
                TetstClassic.Role[i] = hero_sprite[i].name;

                //print(TetstClassic.Role[i]);
            }
            // if (PlayerPrefs.GetString("setrole")=="begin")
            for (int i = 0; i < cards.Length; i++)
            {
                cards[TetstClassic.curr_cards[i]].SetActive(false);
              //  cards[i].GetComponent<MainPlayer>().player.Role = TetstClassic.Role
            }
            if (count < 1)
                cards[0].SetActive(true);




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
