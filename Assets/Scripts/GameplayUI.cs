using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public Text basket_score;
    public Text star_score;
    public static GameplayUI instance;
    // Start is called before the first frame update
    void Start()
    {
        basket_score.text = "0";
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBasketScore(int score)
    {
        basket_score.text = score.ToString();
    }

    public void IncreaseBasketScore()
    {
        basket_score.text += 1;
    }
}
