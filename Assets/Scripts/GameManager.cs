using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite Sprite_Gu;
    [SerializeField] private Sprite Sprite_Tyoki;
    [SerializeField] private Sprite Sprite_Pa;
    [SerializeField] private Image Image_Hand;
    [SerializeField] private Button Button_Gu;

    void Start()
    {
        SetRandomHandSprite();
        //Button_Gu.onClick.AsObservable().Subscribe((_) => isGameStart = true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void SetRandomHandSprite()
    {
        int randint = Random.Range(1, 4);
        Debug.Log("randint:"+randint);

        if (randint == 1)
        {            
            Image_Hand.sprite = Sprite_Gu;
        }
        else if (randint == 2)
        {
            Image_Hand.sprite = Sprite_Tyoki;
        }
        else
        {
            Image_Hand.sprite = Sprite_Pa;
        }
    }
}
