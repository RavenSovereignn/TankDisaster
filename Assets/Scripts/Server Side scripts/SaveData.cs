using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveData : MonoBehaviour
{
   
    public TextMeshProUGUI playerDisplay;
    private void Awake()
    {
        if (DBManager.username == null)
        {
             UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
        }
        playerDisplay.text = "Player: " + DBManager.username;
    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);

        WWW www = new WWW("http://localhost/savedata.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game saved.");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }
        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
