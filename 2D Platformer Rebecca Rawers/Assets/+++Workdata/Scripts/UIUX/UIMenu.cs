using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevelSelection;
    [SerializeField] private Button exitButton;
    
    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;

    [SerializeField] private string[] levelNames;
    
    //I need: MainPanel, Buttons for NewGame.LevelSelection. ExitButton.
    //MainPanel->LevelSelection: Make buttons for 3 levels and return button
    
    // Start is called before the first frame update
    void Start()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
        
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonNewGame.onClick.AddListener(LoadLevel1);
        buttonBackToMain.onClick.AddListener(ShowMainPanel);
        
        buttonLevel1.onClick.AddListener(LoadLevel1);
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);

        exitButton.onClick.AddListener(ExitGame);

        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[1]))
        {
           if (PlayerPrefs.GetInt(levelNames[1]) == 1)
           {
               buttonLevel2.interactable = true;
           }
        }

        buttonLevel3.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[2]))
        {
            if (PlayerPrefs.GetInt(levelNames[2]) == 1)
            {
                buttonLevel3.interactable = true;
            }
        }
    }
 
    //LevelSelection: Loading MainMenu and Levels
    void ShowLevelSelection()
    {
        panelMain.HideCanvasGroup();
        panelLevelSelection.ShowCanvasGroup();
    }

    void ShowMainPanel()
    {
        panelMain.ShowCanvasGroup();
        panelLevelSelection.HideCanvasGroup();
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene(levelNames[0]);
    }
   
    void LoadLevel2()
    {
        SceneManager.LoadScene(levelNames[1]);
    }
    
    void LoadLevel3()
    {
        SceneManager.LoadScene(levelNames[2]);
    }

    //Exit. Don't forget to add Serializedfield above
    void ExitGame()
    {
        Application.Quit();
    }
}
