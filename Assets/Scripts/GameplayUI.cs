using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public Text basket_score_text;
    public Text star_score_text;
    private int basket_score = 0;
    private int star_score = 0;
    public static GameplayUI instance;
    // Start is called before the first frame update
    void Start()
    {
        basket_score_text.text = "0";
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
        basket_score_text.text = score.ToString();
    }

    public void IncreaseBasketScore()
    {
        basket_score++;
        ChangeBasketScore(basket_score);
    }
}
