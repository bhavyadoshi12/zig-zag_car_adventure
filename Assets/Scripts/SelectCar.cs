using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour
{
    public static SelectCar instance;
    [SerializeField] Button prevBtn;
    [SerializeField] Button nextBtn;
    [SerializeField] Button useBtn;
    [SerializeField] GameObject buyPanel;

    int currentCar;
    string ownCarIndex;
    Color redColor = new Color(1f,0.1f,0.1f,1f);
    Color greenColor = new Color(0.5f,1f,0.4f,1f);

    int haveStars, haveDiamonds;
    int carvalue =700;
    [Header("Buy Panel")]
    public Text haveStarsText; 
    public Text haveDiamondText;
    public Text needMoreText;
    public Button buyCarBtn;
    public Button closePanelBtn;
    public Button buyStar_diamond_btn;

   

    private void Awake()
    {
        if (instance == null)
        {
            instance=this;
        }
        ChangeCar(0);
    }//Awake

    private void Start()
    {
        haveStars = PlayerPrefs.GetInt("totalStar");
        haveDiamonds = PlayerPrefs.GetInt("totalDiamond");
       
        if(haveStars<700)
        {
            buyCarBtn.interactable = false;
        }
    }

    

    void ChooseCar(int _index)
    {
        prevBtn.interactable = (_index != 0);
        nextBtn.interactable =(_index != transform.childCount -1);
        for(int i = 0; i< transform.childCount; i++)
        {
            string carNo = "CarNo" + i; 
            if(i == 0) 
            {
                PlayerPrefs.SetInt(carNo, 1); 
            }
            transform.GetChild(i).gameObject.SetActive(i ==_index);
        }    

    }//Choose Car

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        ChooseCar(currentCar);
        ownCarIndex = "CarNo" + currentCar;
        if(PlayerPrefs.GetInt(ownCarIndex)==1)
        {
            useBtn.GetComponent<Image>().color = greenColor;
            useBtn.GetComponentInChildren<Text>().text = "SELECT";
        }
        else
        {
            useBtn.GetComponent<Image>().color = redColor;
            useBtn.GetComponentInChildren<Text>().text = "BUY";
        }


    }//ChangeCar

    public void useBtnClick()
    {
        haveStars =PlayerPrefs.GetInt("totalStar");
        haveDiamonds =PlayerPrefs.GetInt("totalDiamond");

        if(PlayerPrefs.GetInt(ownCarIndex) ==1)
        {
            PlayerPrefs.SetInt("SelectCar", currentCar);
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            buyPanel.SetActive(true);
            haveStarsText.text ="You Have" + haveStars + "Stars";
            haveDiamondText.text ="You Have" + haveDiamonds + "Diamonds";
            if(haveStars < carvalue)
            {
                int needStarInt = carvalue - haveStars;
                buyCarBtn.interactable = false;
                needMoreText.text = needStarInt+ "more star needed";
            }
            else
            {
              buyCarBtn.interactable = true;
              needMoreText.text = "Value :"+ carvalue +"Stars";  
            }
           
            if(haveDiamonds<1)
            {
                buyStar_diamond_btn.interactable=false;
            }
            prevBtn.interactable = false;
            nextBtn.interactable = false;
            useBtn.interactable = false;
           
        }
        
    }//UseBtnClick

    public void closePanel()
    {
        buyPanel.SetActive(false);
        prevBtn.interactable = true;
        nextBtn.interactable = true;
        useBtn.interactable = true;
    }

    public void BuyStars()
    {
        
        

        if(haveDiamonds>0)

        {
            buyStar_diamond_btn.interactable = true;
            haveDiamonds -= 1;
            haveStars += 10;
            PlayerPrefs.SetInt("totalStar",haveStars);
            PlayerPrefs.SetInt("totalDiamond",haveDiamonds);
            SetText();
        }
        else
        {
            buyStar_diamond_btn.interactable = false;

        }
        
        

    }

    public void EarnStar()
    {
        haveStars = PlayerPrefs.GetInt("totalStar");
        haveStars += 100;
        PlayerPrefs.SetInt("totalStar", haveStars);
        SetText();
        
    }//EarnStar

    void SetText()
    {
        buyPanel.SetActive(true);

        haveStarsText.text ="You Have" + haveStars + "Stars";
        haveDiamondText.text ="You Have" + haveDiamonds + "Diamonds";
        if(haveStars < carvalue)
        {
            int needStarInt = carvalue - haveStars;
            buyCarBtn.interactable = false;
            needMoreText.text = needStarInt+ "more star needed";
        }
           
        if(haveDiamonds<1)
        {
            buyStar_diamond_btn.interactable = false;
        }
            
        
        prevBtn.interactable = false;
        nextBtn.interactable = false;
        useBtn.interactable = false;

    }//SetText

    public void BuyThisCar()
    {
        if(haveStars<700)
        {
            PlayerPrefs.SetInt(ownCarIndex,1);
            haveStars += -carvalue;
            PlayerPrefs.SetInt("totalStar",haveStars);
            int currentMinOne = currentCar - 1;
            ChangeCar(currentMinOne);
            
            closePanel();
        }
    }



}
