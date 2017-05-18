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
        panel.SetActive(false);
        fon_dark.SetActive(false);
    }
}
