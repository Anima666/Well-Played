using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_setting_panel : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        RectTransform transform = contentPanel.gameObject.transform.transform as RectTransform;
        Vector2 position = transform.anchoredPosition;
        position.y -= transform.rect.height;
        transform.anchoredPosition = position;
    }
    public Animator contentPanel;
    public Animator gearImage;
    public void ToggleMenu()
    {
        bool isHidden = gearImage.GetBool("IsHidden");
        if (gearImage.enabled == false)
            gearImage.enabled = true;
            gearImage.SetBool("IsHidden", !isHidden);

       if (contentPanel.enabled==false)
        contentPanel.enabled = true;

         isHidden = contentPanel.GetBool("isHidden");
        contentPanel.SetBool("isHidden", !isHidden);

        
    }
}
