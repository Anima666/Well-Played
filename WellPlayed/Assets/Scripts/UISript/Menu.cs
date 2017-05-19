using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



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
    public void SetRole()
    {
        
        TetstClassic.Role[TetstClassic.count] = "322";
        TetstClassic.count++;
        SceneManager.LoadScene("setRole");
       
    }
    public void OpenSetRole()
    {
        TetstClassic.count = 0;
        SceneManager.LoadScene("setRole");
    }
    //public void ShowAd()
    //{
    //    if (Advertisement.IsReady())
    //    {
    //        Advertisement.Show();
    //    }
    //}

    //public void ShowRewardedAd()
    //{
    //    if (Advertisement.IsReady("rewardedVideo"))
    //    {
    //        var options = new ShowOptions { resultCallback = HandleShowResult };
    //        Advertisement.Show("rewardedVideo", options);
    //    }
    //}

    //private void HandleShowResult(ShowResult result)
    //{
    //    switch (result)
    //    {
    //        case ShowResult.Finished:
    //            Debug.Log("The ad was successfully shown.");

    //            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond")+100);
    //            GetComponent<GetMoney>().RefreshMoney();

    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("The ad was skipped before reaching the end.");
    //            break;
    //        case ShowResult.Failed:
    //            Debug.LogError("The ad failed to be shown.");
    //            break;
    //    }
    //}
}

