using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;




public class Menu : MonoBehaviour {

	
	public void OpenMenu ()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
            SceneManager.LoadScene("MainScene");
	}
    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void OpenMain()
    {
        
        SceneManager.LoadScene("mainmenu");
    }
    public void opnLanguageSetting()
    {
        SceneManager.LoadScene("changeLan");
    }
    public void BuyCase()
    {
        SceneManager.LoadScene("opencase");

        TetstClassic.lastscene = SceneManager.GetActiveScene().name;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public GameObject panel;
    public void OpenDonatPanel()
    {
        panel.SetActive(true);
    }
    public void CloseDonatPanel()
    {
        panel.SetActive(false);
    }
    public void GoLastScene()
    {
        SceneManager.LoadScene(TetstClassic.lastscene);
    }
    Role_player nr = new Role_player();
    public void SetRole()
    {  
        nr.role = TetstClassic.Role[TetstClassic.count];
        nr.name = TetstClassic.last_nickname;
        TetstClassic.role_playes.Add(nr);
      
        TetstClassic.count++;
        SceneManager.LoadScene("setRole");

    }
    public static void OffUpPanel()
    {
        GameObject up_panel = GameObject.FindGameObjectWithTag("up_panel");
        up_panel.SetActive(false);
    }
    public void OpenSetRole()
    {
        TetstClassic.count = 0;
        SceneManager.LoadScene("setRole");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = ShowSimple };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    public void ShowRewardedAdWinPanel()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = RewaerWinPanel };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void RewaerWinPanel(ShowResult result)
    {
        if (result== ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") +200);

        }
    }
    private void ShowSimple(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 5);

        }
    }

}

