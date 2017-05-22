using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetMoney : MonoBehaviour {

    public int coins;
    public int diamond;
    public InputField inputfield;

    public void setmoney()
    {
        if (inputfield.text != "")
        {
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetInt("Diamond", diamond);
            PlayerPrefs.SetInt("continue", 1);
            SceneManager.LoadScene("mainmenu");
            TetstClassic.lastscene = SceneManager.GetActiveScene().name;
        }
    }
}
