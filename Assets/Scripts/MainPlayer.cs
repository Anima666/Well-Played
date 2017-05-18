using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System.Collections;


public class MainPlayer : MonoBehaviour {

    

    private void LoadSceneOfDataPlayer()
    {
        SceneManager.LoadScene("dataplayer");
        TetstClassic.pl = player;
        TetstClassic.spite = sp;
        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
       
    }
    TextMesh text;
    public bool checkExtend ;
    SpriteRenderer[] backGroundSprites;
    void Awake()
    {
        text = GetComponentInChildren<TextMesh>();
        backGroundSprites = GetComponentsInChildren<SpriteRenderer>();
    }
    public Player player  = new Player();
    public Sprite sp;

    void Start ()
    {

    }
 
    public void Refesh ()
    {
        SetTextSize();
        GetComponentInChildren<Image>().sprite = sp;


        for (int i = 0; i < backGroundSprites.Length; i++)
        {
            if (backGroundSprites[i].tag == "rarity")
                CheckRar(backGroundSprites[i]);
        }
    }

    private void SetTextSize()
    {
        text.fontSize = 220;
        text.text = player.nickname;
        if (player.nickname.Length > 9)
            text.fontSize = text.fontSize - ((player.nickname.Length - 9) * 17);
    }
    private void CheckRar(SpriteRenderer render)
    {
        Color32 blue_color = new Color32(51,36,152,255);
        if (player.rarity == 0)
            render.color = Color.black;
        if (player.rarity == 1)
           render.color = blue_color; 
        if (player.rarity == 2)
            render.color = Color.yellow;
    }
    public void TurnEffects(GameObject ps)
    {
        if (player.rarity != 2)
            ps.SetActive(false);
    }

    //public void OnMouseEnter()
    //{
    //    if (checkExtend!=true)
    //    transform.localScale = new Vector2(0.7f, 0.7f);
        
    //}
    //public void OnMouseExit()
    //{
    //    if (checkExtend != true)
    //        transform.localScale = new Vector2(0.6f, 0.6f);
    //}
    void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name == "setRole")
        {
            TetstClassic.curr_cards[TetstClassic.count] = int.Parse(this.name);
            TetstClassic.last_nickname = player.nickname;

        }
       LoadSceneOfDataPlayer();
    }
}
