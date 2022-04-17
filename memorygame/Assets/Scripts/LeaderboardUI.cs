using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    GameObject timeobj;
    GameObject pointsobj;


    public void Setup(string time, string points) 
    {
        timeobj = transform.GetChild(0).gameObject;
        pointsobj = transform.GetChild(1).gameObject;

        timeobj.GetComponent<TextMeshProUGUI>().text = time;
        pointsobj.GetComponent<TextMeshProUGUI>().text = points;
    }

 
}
