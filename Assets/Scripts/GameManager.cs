using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite Sprite_Gu;
    [SerializeField] private Sprite Sprite_Tyoki;
    [SerializeField] private Sprite Sprite_Pa;

    [SerializeField] private Image Image_Hand;

    [SerializeField] private Button Button_Gu;
    [SerializeField] private Button Button_Tyoki;
    [SerializeField] private Button Button_Pa;

    [SerializeField] private AudioSource Audio_Correct;
    [SerializeField] private AudioSource Audio_InCorrect;

    [SerializeField] private Text Text_Point;

    [SerializeField] private GameObject Canvas_End;

    private int Point = 0;
    private int prevint = 0;
    void Start()
    {
        SetRandomHandSprite();
        Text_Point.text = "POINT：" + Point + "/10";
        Button_Gu.onClick.AsObservable().Subscribe((_) => OnClickedHand(Sprite_Pa));
        Button_Tyoki.onClick.AsObservable().Subscribe((_) => OnClickedHand(Sprite_Gu));
        Button_Pa.onClick.AsObservable().Subscribe((_) => OnClickedHand(Sprite_Tyoki));
    }


    void OnClickedHand(Sprite sprite_lose)
    {

        if (Image_Hand.sprite == sprite_lose)
        {
            Correct();
        }
        else
        {
            InCorrect();
        }
        SetRandomHandSprite();
    }


    void Correct()
    {

        Audio_Correct.Play();
        Point++;
        Text_Point.text = "POINT：" + Point + "/10";
        
        if (Point == 10)
        {
            Canvas_End.SetActive(true);
        }
    }

    void InCorrect()
    {

        Audio_InCorrect.Play();
        Point--;
        Text_Point.text = "POINT" + Point + "/10";

    }

    void SetRandomHandSprite()
    {
        int randint = Random.Range(1, 4);
        
        while (randint== prevint)
        {
            randint = Random.Range(1, 4);
        }
        prevint = randint;

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

    public void ReStart()
    {
       
        SceneManager.LoadScene("Game");
    }
}
