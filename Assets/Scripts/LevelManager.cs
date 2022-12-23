using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject basket;       //Prefab for basket
    List<GameObject> basket_pool;   //Pool of baskets
    float start_number_of_basket=3; //Number of baskets in pool
    float basket_distance = 2;      //Distance within draws new basket
    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        basket_pool = new List<GameObject>();
        InitBasketPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitBasketPool()
    {
        for (int i = 0; i < start_number_of_basket; i++)
        {
            GameObject basket_temp = Instantiate(basket);
            //basket_temp.SetActive(false);
            basket_pool.Add(basket_temp);
            basket_pool[i].SetActive(false);
        }
    }

    public void AddBasket(Vector2 position)
    {
        for(int i=0;i<start_number_of_basket;i++)
        {
            if (!basket_pool[i].activeInHierarchy)
            {
                basket_pool[i].transform.position = position;
                basket_pool[i].SetActive(true);
                LoopManager.instance.AddResetObject(basket_pool[i].transform);
                break;
            }
        }
    }
    
    public void DeleteBasket(Transform basket)
    {
        basket.parent.gameObject.SetActive(false);
        basket.transform.rotation = Quaternion.identity;
    }

    public void GenerateUpLevel()
    {
        Vector2 temp_position = Random.insideUnitCircle * basket_distance;
        temp_position.y = Mathf.Abs(temp_position.y);
        AddBasket(temp_position);
    }
}
