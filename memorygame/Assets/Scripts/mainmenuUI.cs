using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainmenuUI : MonoBehaviour
{
    public GameObject game;
    public Animator animate;
    public GameObject lbmenu;

    private void Start()
    {
        animate.Play("uimainmenuopen");
    }

    public void  menuopen() //why this is different from card animations they are better written also bool to check where the menu is wrong place
    {
        animate.Play("uimainmenuopen");
    }

    public void menuclose()
    {
        animate.Play("uimainmenu");
    }

    public void button1() 
    {
        game.GetComponent<gameAdmin>().StartGame(8);
        menuclose();
    }

    public void leaderboards() 
    {
      
        lbmenu.SetActive(true);//we are going the lazy route
       
         
    }

    public void button2() 
    {
        game.GetComponent<gameAdmin>().StartGame(18);
        menuclose();
    }

    public void Restartgame()
    {
        game.GetComponent<gameAdmin>().restartgame();
    }
}
