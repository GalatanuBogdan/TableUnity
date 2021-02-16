using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentLine;
    public int currentColumn;
    public int whatIsPutted; //0-nu este nimic pus. //1-daca este pusa o piesa albastra. //2-daca este pusa o piesa rosie
    void Start()
    {
        
    }

    public void DetectPosibleMove()
    {
       
        int countClicks = GameObject.Find("GameManager").GetComponent<GameManager>().countClicks;
        Vector2 currentTap = new Vector2(currentLine, currentColumn);
        if (countClicks == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().click1 = currentTap;
            GameObject.Find("GameManager").GetComponent<GameManager>().countClicks++;
        }
        if (countClicks == 1)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().click2 = currentTap;
            //mutarea sau verificarea mutarii
            Move(GameObject.Find("GameManager").GetComponent<GameManager>().click1, GameObject.Find("GameManager").GetComponent<GameManager>().click2);
            GameObject.Find("GameManager").GetComponent<GameManager>().countClicks = 0;
        }
    }

    void Move(Vector2 v1, Vector2 v2)
    {
        //click-ul initial reprezinta starea initiala.
        //de unde plecam punem empty
        GameObject buttonStart;
        GameObject buttonEnd;
        buttonStart = GameObject.Find("Table").GetComponent<GenerateTable>().buttons[(int)v1.x, (int)v1.y];
        buttonEnd = GameObject.Find("Table").GetComponent<GenerateTable>().buttons[(int)v2.x, (int)v2.y];

        int whoIsOnButtonStart = buttonStart.GetComponent<BtnController>().whatIsPutted;
        int whoIsOnButtonEnd = buttonEnd.GetComponent<BtnController>().whatIsPutted;
        if (whoIsOnButtonStart == 1 || whoIsOnButtonStart == 2)
        {
            if(whoIsOnButtonEnd == 0)
            {
                if(whoIsOnButtonStart == 1)
                {
                    buttonEnd.GetComponent<Image>().sprite = GameObject.Find("Table").GetComponent<GenerateTable>().blueImage;
                    buttonStart.GetComponent<Image>().sprite = GameObject.Find("Table").GetComponent<GenerateTable>().emptyImage;
                    buttonStart.GetComponent<BtnController>().whatIsPutted = 0;
                    buttonEnd.GetComponent<BtnController>().whatIsPutted = 1;
                }
                if (whoIsOnButtonStart == 2)
                {
                    buttonEnd.GetComponent<Image>().sprite = GameObject.Find("Table").GetComponent<GenerateTable>().redImage;
                    buttonStart.GetComponent<Image>().sprite = GameObject.Find("Table").GetComponent<GenerateTable>().emptyImage;
                    buttonStart.GetComponent<BtnController>().whatIsPutted = 0;
                    buttonEnd.GetComponent<BtnController>().whatIsPutted = 2;

                }
            }
        }

    }

}


