using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameoverUI : MonoBehaviour
{
    public TextMeshProUGUI score;
    public void setupui(float puan,int time) 
    {
        score.text = "puan:"+puan+"kalan sure:"+time;
    }

   public void button1() 
    {
    
    }

    public void button2()
    {
    
    }
}
