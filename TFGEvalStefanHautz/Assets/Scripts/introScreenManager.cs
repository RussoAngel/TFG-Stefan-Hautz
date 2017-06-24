using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


public class introScreenManager : MonoBehaviour {

    public Button continueButt, beginButt;
    public InputField correoFrom, correoTo, nombre, password;
    public GameObject panelInfo, panelAuthors, panelAbout, animacion;


    public void Start()
    {
        panelAbout.SetActive(false);
        panelAuthors.SetActive(false);
        panelInfo.SetActive(false);
    }

    public void StartG(string name)
    {
        //Application.LoadLevel(Application.loadedLevel);
        if (IsEmail(correoFrom.text)) {
            PlayerPrefs.SetString("fromAddress", correoFrom.text);
            correoFrom.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }
        else {
            correoFrom.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
        if (IsEmail(correoTo.text))
        {
            PlayerPrefs.SetString("toAddress", correoTo.text);
            correoTo.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }
        else {
            correoTo.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
        if (nombre.text.Length > 6)
        {
            PlayerPrefs.SetString("playerName", nombre.text);
            nombre.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }
        else {
            nombre.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
        if (password.text.Length > 6) {
            PlayerPrefs.SetString("playerPassword", password.text);
            password.GetComponent<Image>().color = new Color32(0x1A, 0xD0, 0x39, 0xFF);
        }
        else {
            password.GetComponent<Image>().color = new Color32(0xF6, 0x10, 0x1E, 0xFF);
        }
        if (PlayerPrefs.HasKey("fromAddress") && PlayerPrefs.HasKey("toAddress") && PlayerPrefs.HasKey("playerName") && PlayerPrefs.HasKey("playerPassword"))
        {
            SceneManager.LoadScene(name);
            PlayerPrefs.SetInt("totalStars", 0);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ContinueG() {
        SceneManager.LoadScene(PlayerPrefs.GetString("savedLevel"));
    }

    private void Update()
    {
        if (!PlayerPrefs.HasKey("savedLevel"))
        {
            continueButt.interactable = false;
            beginButt.interactable = true;
        }
        else {
            continueButt.interactable = true;
            beginButt.interactable = false;
        }

    }
    public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    public static bool IsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }

    public void openInfo() {
        panelInfo.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeInfo() {
        panelInfo.SetActive(false);
        animacion.SetActive(true);
    }

    public void openAuthors() {
        panelAuthors.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeAuthors()
    {
        panelAuthors.SetActive(false);
        animacion.SetActive(true);
    }

    public void openAbout() {
        panelAbout.SetActive(true);
        animacion.SetActive(false);
    }

    public void closeAbout()
    {
        panelAbout.SetActive(false);
        animacion.SetActive(true);
    }


}
