using UnityEngine;
using System.Collections;

public class CloseAboutAuthor : MonoBehaviour {

    public GameObject panel;
    public GameObject fon_dark;
    void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown ()
    {
        if (panel != null)
            panel.SetActive(false);
        if (fon_dark!=null)
        fon_dark.SetActive(false);
    }
}
