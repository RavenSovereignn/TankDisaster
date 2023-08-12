using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public GameObject WrongInputUI;

    public Button submitButton;
    private char[] SpecialChars = "!@;:,.%^&*£$#~".ToCharArray();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && usernameField.text.Length >= 8 && passwordField.text.Length >= 8)
        {
            submitButton.onClick.Invoke();
        }
    }

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", usernameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/login.php", form);
        yield return www;
        Debug.Log(www.error);
        if (www.text[0] == '0')
        {
            DBManager.username = usernameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            Debug.Log("User logged in successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        int indexOfUsername = usernameField.text.IndexOfAny(SpecialChars);
        int indexOfPassword = passwordField.text.IndexOfAny(SpecialChars);
        
        
        submitButton.interactable = (usernameField.text.Length >= 8 && passwordField.text.Length >= 8 && indexOfUsername == -1 && indexOfPassword == -1);

        if (!submitButton.interactable)
        {
            WrongInputUI.SetActive(true);
        }
        else { WrongInputUI.SetActive(false); }
    }
    public void GoBackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
