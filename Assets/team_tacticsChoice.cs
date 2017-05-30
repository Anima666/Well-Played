using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class team_tacticsChoice : MonoBehaviour {

    public GameObject on_minimapOfflane;
    public GameObject supp_iziLine;
   

    public GameObject start_panel;
    public GameObject match_panel;
    public void SoloHard ()
    {
        on_minimapOfflane.SetActive(false);
        supp_iziLine.SetActive(true);
        SetActiveAndFalsePanel();

    }

    private void SetActiveAndFalsePanel()
    {
        start_panel.SetActive(false);
        match_panel.SetActive(true);

    }

    public void TwoCarry()
    {
        on_minimapOfflane.name = "carry";
        SetActiveAndFalsePanel();

    }

    // Update is called once per frame
    void Start ()
    {
        
    }
}
