using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_panel_with_team : MonoBehaviour
{
    Animation anim;
    bool up = true;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
	void OnMouseDown()
    {
       
        if (up == true)
        {
            anim.Play();
            up = false;
        }
        else 
       // if (anim.isPlaying==true)
        {
            anim.Play("move_panel_back");
            up = true;
        }
    }
}
