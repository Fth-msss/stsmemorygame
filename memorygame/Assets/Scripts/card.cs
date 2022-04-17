using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
   
    bool isup=false;
    public bool pairfound = false;
    public cardProperties properties;
    public GameObject gameAdmin;
    public Sprite cardback;
    public Animator animate;
    public AnimationClip open;
    public AnimationClip close;
    // Start is called before the first frame update
  

    private void OnMouseDown()
    {
        
        if (!isup&&!pairfound) { gameAdmin.GetComponent<gameAdmin>().HamleYap(this.gameObject); }
        
    }

    public void ac() 
    {
        isup = true;
        animate.Play("cardopen");  
    }

    public void acanim() //fires after animation ends
    {
        GetComponent<SpriteRenderer>().sprite = properties.cardSprite;
    }

    public void kapa() 
    {
        isup = false;
        animate.Play("cardclose");
    }

    public void kapaanim() //fires after animation ends
    {
        GetComponent<SpriteRenderer>().sprite = cardback;
    }

}
