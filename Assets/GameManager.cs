using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Vector2 click1;
    public Vector2 click2;
    public int countClicks;

    void Start()
    {
        countClicks = 0;
        click1 = Vector2.zero;
        click2 = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
