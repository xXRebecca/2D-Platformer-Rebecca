using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Interactions : MonoBehaviour
{
    private UILevelManager uiLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        uiLevelManager = FindObjectOfType<UILevelManager>();
    }

    // Code the win and lose panel followed by a text.
    //First win panel
    //Second lose panel
    private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.CompareTag("Goal"))
           {

               Debug.Log("you Win");
               uiLevelManager.OnGameWin();
           }
               
           
           else if (other.CompareTag("Death"))
           {
               Debug.Log("you lose");
               uiLevelManager.OnGameLose();
           }
           
           else if (other.CompareTag("Coin"))
           {
               uiLevelManager.AddCoin();
               Destroy(other.gameObject);
           }
       }
}
