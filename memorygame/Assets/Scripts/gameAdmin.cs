using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class gameAdmin : MonoBehaviour
{
    public float puan;
    public int decksize;
    public GameObject basecard;
    [SerializeField]
    public cardProperties[] cardprops;
    public int hamlesayisi;
    public int cardsleft;
    public GameObject spawnlocation;
    public Sprite cardback;
    public gameUI ui;
    int[] cardlocations;
    List<Vector3> positionArray;
    List<Vector3> positionArrayVertical;
    GameObject secilikart;
    public GameObject gameovermenu;



//6x6 uses waay to many cards it doesnt need. doesnt take multiplying cards into count

    public void StartGame(int size) 
    {
        decksize = size;
        Cardorder();
        Changecardleft();
        MakeDeck(size);
        Starttimer();
    }
 
    int timer;
    public void Starttimer() 
    {
        
        timer = 60;
        StartCoroutine(Time());
       
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(1);
        timer--;
        ui.updatetime(timer);
        if (timer < 1) { Gameover(); yield break; }
        StartCoroutine(Time());
    }

 

    public void Cardorder() 
    {
        cardlocations = new int[decksize * 2 ];
        for (int i=0;i<decksize*2;i++) //get card count in array to randomize
        {     
            cardlocations[i] = i;
        }

        //okay this somehow works?
        cardlocations = cardlocations.OrderBy(x => Random.Range(0, decksize * 2)).ToArray();
        foreach (int number in cardlocations) ;
    }



void MakeDeck(int decksize) 
    {
        if (decksize*2 <= 4 * 4) { CreateGrid(4, 4); }
        else if (decksize*2 <= 6 * 6) { CreateGrid(9, 4); }//make this dynamic
        cardsleft = decksize;
        int i;
        for (i=0;i<decksize;i++) //create cards
        {
            MakeCard(i);
            MakeCard(i);
        }  
    }

    void MakeCard(int cardid) 
    {
        GameObject card = Instantiate(basecard);
        card.name = "cardno:"+cardid;
        card.GetComponent<card>().properties = cardprops[cardid];
        card.GetComponent<card>().cardback = cardback;
        card.GetComponent<card>().gameAdmin = this.gameObject;
        PlaceCard(card);
    }

    int placecounter=0;
    void PlaceCard(GameObject card)//this is not a for loop in make card because i might change cards pos after creation
    {
        card.transform.position = positionArray[cardlocations[placecounter]];
        placecounter += 1;
    }

    void CreateGrid(int sizex,int sizey)
    {
        Vector3 startpos = spawnlocation.transform.position;
        positionArray=new List<Vector3>();
        int i,z;
        for(z=1; z <= sizey; z++) 
        {
            for (i = 0; i < sizex; i++)
            {
                if (i == 0) { positionArray.Add(startpos); }
                else { positionArray.Add(startpos + new Vector3(i*1.3f, 0, 0)); }
            }
            startpos += new Vector3(0,- 1.9f, 0);
        }
    }


    
   public void HamleYap(GameObject tiklananKart) 
   {   
        if (secilikart == null)
        {   
            hamlesayisi++;
            secilikart = tiklananKart;
            secilikart.GetComponent<card>().ac(); 
        }
        else 
        {
            if (tiklananKart.GetComponent<card>().properties.id == secilikart.GetComponent<card>().properties.id) 
            { 
              tiklananKart.GetComponent<card>().ac();
              tiklananKart.GetComponent<card>().pairfound = true;
              secilikart.GetComponent<card>().pairfound = true;
              secilikart = null;
              KartEslestir(); 
            }
            else
            { Debug.Log("kartlar ayni degil");
              tiklananKart.GetComponent<card>().ac();
              StartCoroutine(KartKapa(secilikart, tiklananKart));
              secilikart = null;
              Changepoints(-2);
            }
            hamlesayisi++;         
        }
        Debug.Log("hamlesayisi:"+hamlesayisi+"tiklanankart:"+tiklananKart.name);
        ui.updatehamle(hamlesayisi);
   }

    void KartEslestir() //ikisi ayni
    {
        Changepoints(10);
        cardsleft -= 1;
        Changecardleft();
        Debug.Log("kartlar ayni. kalan kart sayisi:"+cardsleft);
        if (cardsleft <= 0) { Debug.Log("wongame");Gameover(); }
    }

    void Gameover() 
    {
        //get: points,time left,

        gameovermenu.SetActive(true);
        gameovermenu.GetComponent<gameoverUI>().setupui(puan,timer);

    }

    public void restartgame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator KartKapa(GameObject kart1,GameObject kart2)
    {
        yield return new WaitForSeconds(1);
        kart1.GetComponent<card>().kapa();
        kart2.GetComponent<card>().kapa();
    }

    void Changepoints(float point) 
    {
        puan += point;
        ui.updatePoint(puan);
    }

    void Changecardleft() 
    {
        ui.updatecardsleft(cardsleft, decksize);
    }




}
