using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UILevelManager : MonoBehaviour
{

    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonPlayAgain;

    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;

    [SerializeField] private Button buttonBackToMain;
    [SerializeField] private Button buttonBackToMainOnLose;
    
    [SerializeField] private string nameNextScene;

    private int coinCount = 0;
    [SerializeField] private TextMeshProUGUI txtCoinCount;
    
    //Important functions: Serialised field for the inspector, don't forget about voids, public, strings.
    //Add the buttons to the functions in the inspector of your canvas.
    
    //Coin, Panels for win and lose, MainMenu
    
    // Start is called before the first frame update
    void Start()
    //Write codes for the buttons onClick function to turn on and off panels
    {
        Time.timeScale = 1f;
        txtCoinCount.text = coinCount.ToString();
        //panelWin.alpha = 0f;
        //panelWin.interactable = false;
        //panelWin.blocksRaycasts = false;
        
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        //hide win and lose
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonPlayAgain.onClick.AddListener(RestartLevel);
        buttonBackToMain.onClick.AddListener(BackToMenu);
        buttonBackToMainOnLose.onClick.AddListener(BackToMenu);
    }

    public void OnGameWin()
    //playerprefs my objects and assets presented
    
    {
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene, 1);
        Time.timeScale = 0f;
        //win screen show
    }

    public void OnGameLose()
    {
        panelLose.ShowCanvasGroup();
        Time.timeScale = 0f;
        //lose screen show
    }

    public void AddCoin()
    {
        coinCount++;
        txtCoinCount.text = coinCount.ToString();
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //reload current Level
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nameNextScene);
        //
    }
    
    void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //please stop forgetting about serializedfield above 
    //look on canvas and check if you loaded all buttons into the inspector
}

public static class UIExtensions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}