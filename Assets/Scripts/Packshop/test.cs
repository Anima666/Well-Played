using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    private Animation anim;
    private AnimationClip[] an;
    public GameObject obj_animationsclip;
    int count_of_press = 0;

	void Start ()
    {
        anim = GetComponent<Animation>();
        an = obj_animationsclip.GetComponent<AnimationsClip>().an;
        open = false;
    }

    // Update is called once per frame
    public bool open=false;
    void OnMouseEnter()
    {

     
        if (open == false)
        {
            CheckRarity();
            anim.Play();
        }

       

    }
    void OnMouseDown()
    {
        
        count_of_press++;
        if (count_of_press == 2)
        {
           // print("1");
            if (open == false)
            {
                open = true;
                count_of_press = 0;
                anim.Play("rotate");
               
            }
            
        }
    }
    void OnMouseExit()
    {
        if (open == false)
        {
            anim.Stop();
            count_of_press = 0;
        }

    }
    int rarity;
    void CheckRarity()
    {
        rarity = GetComponentInChildren<MainPlayer>().player.rarity;
        if (rarity == 0)
            anim.clip = an[2];
        if (rarity == 1)
            anim.clip = an[1];
        if (rarity == 2)
            anim.clip = an[0];
    }
    void Update()
    {
      
    }
}
