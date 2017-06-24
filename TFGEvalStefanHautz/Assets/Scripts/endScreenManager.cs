using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class endScreenManager : MonoBehaviour
{
    public Text scores, starNumber;

    private void Start()
    {
        scores.text = "Tiempo total: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("totalTime")) + "\t Fallos totales: " + PlayerPrefs.GetInt("totalFails");
        starNumber.text = PlayerPrefs.GetInt("totalStars").ToString();
        sendMail();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void restart() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("intro");
    }

    void sendMail()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress(PlayerPrefs.GetString("fromAddress"));
        mail.To.Add(PlayerPrefs.GetString("toAddress"));
        mail.Subject = "Puntuaciones de " + PlayerPrefs.GetString("playerName");
        mail.Body = "Tiempo Fase 1: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel1")) + "\t Fallos Fase 1: " + PlayerPrefs.GetInt("failsLevel1") +
            "\nTiempo Fase 2: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel2")) + "\t Fallos Fase 2: " + PlayerPrefs.GetInt("failsLevel2") +
            "\nTiempo Fase 3: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel3")) + "\t Fallos Fase 3: " + PlayerPrefs.GetInt("failsLevel3") +
            "\nTiempo Fase 4: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel4")) + "\t Fallos Fase 4: " + PlayerPrefs.GetInt("failsLevel4") +
            "\nTiempo Fase 5: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel5")) + "\t Fallos Fase 5: " + PlayerPrefs.GetInt("failsLevel5") +
            "\nTiempo Fase 6: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel6")) + "\t Fallos Fase 6: " + PlayerPrefs.GetInt("failsLevel6") +
            "\nTiempo Fase 7.1: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel7")) + "\t Fallos Fase 7.1: " + PlayerPrefs.GetInt("failsLevel7") +
            "\nTiempo Fase 7.2: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("timeLevel8")) + "\t Fallos Fase 7.2: " + PlayerPrefs.GetInt("failsLevel8") +
            "\nTiempo total: " + String.Format("{0:0.00}", PlayerPrefs.GetFloat("totalTime")) + "\t Fallos totales: " + PlayerPrefs.GetInt("totalFails");

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(PlayerPrefs.GetString("fromAddress"), PlayerPrefs.GetString("playerPassword")) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");

    }
}
