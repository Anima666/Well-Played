using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputnametea : MonoBehaviour {

    // Use this for initialization
    public Text text;


    void Start ()
    {
	
	}
	
	public void Press ()
    {
        PlayerPrefs.SetString("Team", text.text);
        Debug.Log(text.text);
        SceneManager.LoadScene("mainmenu");

	}
}
