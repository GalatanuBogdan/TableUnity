using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateTable : MonoBehaviour
{
    public GameObject btn;
    public Transform trans;
    public GameObject[,] buttons = new GameObject[8, 7];
    public Sprite redImage;
    public Sprite blueImage;
    public Sprite emptyImage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject generatedObj;
        Vector3 spawnPos = new Vector3(50, -50, 0);
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                generatedObj = Instantiate(btn, trans);
                generatedObj.GetComponent<RectTransform>().anchoredPosition = spawnPos;
                generatedObj.GetComponent<BtnController>().currentLine = i;
                generatedObj.GetComponent<BtnController>().currentColumn = j;
                generatedObj.GetComponent<BtnController>().whatIsPutted = 0;//initial nu putem nimic!
                buttons[i, j] = generatedObj;
                spawnPos.x += 100;
            }
            spawnPos.y -= 100;
            spawnPos.x = 50;
        }

        for (int i = 0; i < 7; i++)
            if (i % 2 == 0)
            {
                buttons[0, i].GetComponent<Image>().sprite = redImage;
                buttons[0, i].GetComponent<BtnController>().whatIsPutted = 2;
            }
        for (int i = 0; i < 7; i++)
            if (i % 2 == 1)
            {
                buttons[1, i].GetComponent<Image>().sprite = redImage;
                buttons[1, i].GetComponent<BtnController>().whatIsPutted = 2;
            }
        for (int i = 0; i < 7; i++)
            if (i % 2 == 0)
            {
                buttons[7, i].GetComponent<Image>().sprite = blueImage;
                buttons[7, i].GetComponent<BtnController>().whatIsPutted = 1;
            }
        for (int i = 0; i < 7; i++)
            if (i % 2 == 1)
            {
                buttons[6, i].GetComponent<Image>().sprite = blueImage;
                buttons[6, i].GetComponent<BtnController>().whatIsPutted = 1;
            }
    }

}
