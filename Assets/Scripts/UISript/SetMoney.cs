using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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
            Global2 gl = new Global2();
            gl.SaveMyTeam("my_command",new List<Player>());
            TetstClassic.lastscene = SceneManager.GetActiveScene().name;
        }
    }
}
