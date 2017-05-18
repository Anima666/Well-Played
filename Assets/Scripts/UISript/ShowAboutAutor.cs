using UnityEngine;
using System.Collections;

public class ShowAboutAutor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public GameObject panel;
    public GameObject fon_dark;

    public void Press ()
    {
        fon_dark.SetActive(true);
        panel.SetActive(true);
       
    }
}
