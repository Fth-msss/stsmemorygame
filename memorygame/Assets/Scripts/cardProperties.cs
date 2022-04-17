using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class cardProperties : ScriptableObject
{
    public string cardName;
    public int id;
    public Sprite cardSprite;

}
