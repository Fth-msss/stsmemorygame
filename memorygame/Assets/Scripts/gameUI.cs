using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameUI : MonoBehaviour
{
    public TextMeshProUGUI pointtext;
    public TextMeshProUGUI pairtext;
    public TextMeshProUGUI hamletext;
    public TextMeshProUGUI timetext;

    public GameObject mainmenu;
    public GameObject leaderboards;

    bool menuopen;
    public void Openmenu() //settings button on top ui bar
    {
        if (menuopen) { menuopen = !menuopen;mainmenu.GetComponent<mainmenuUI>().menuopen(); }
        else { menuopen = !menuopen; mainmenu.GetComponent<mainmenuUI>().menuclose(); }
    }


    public void updatecardsleft(float cardleft,int a) 
    {
        pairtext.text = "pairsleft:"+ cardleft.ToString()+"/"+a.ToString();
    }
    

    public void updatePoint(float points) 
    {
        pointtext.text = "puan:"+points.ToString();
    }

    public void updatehamle(int hamlesayi) 
    {
        hamletext.text = "hamle:"+hamlesayi.ToString();
    }

    public void updatetime(int time) 
    {
        timetext.text = "süre:" + time.ToString();
    }
    


}
