using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPausedMenu;
    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
       
        //youdiedboolean = youDiedBool.youdiedbool;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPausedMenu = !isPausedMenu;
            
            //Debug.Log("Case 1");
        }
        if (isPausedMenu)
        {
            ActivateMenu();
            //Debug.Log("Case 5");
        }
        if(!isPausedMenu)
        {
            DeactivateMenu();
            //Debug.Log("Case 6");
        }
    }
  
    void ActivateMenu ()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DeactivateMenu ()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        isPausedMenu = false;
    }
    public void Controls()
    {
        pauseMenuUI.SetActive(false);
    }
    public void ControlsBack()
    {
        pauseMenuUI.SetActive(true);
    }
           //player options(later one)
}
