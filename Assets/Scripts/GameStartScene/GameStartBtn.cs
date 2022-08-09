using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartBtn : MonoBehaviour
{
    float alpha = 1;
    bool IsMaxValue = true;
    private void Update()
    {
        
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Loading.LoadScene("BattleScene");
            }
        }

        if ( Input.GetMouseButtonDown(0))
        {
            Loading.LoadScene("BattleScene");
        }

        if(gameObject.GetComponent<Image>().color.a >= 0.2 && IsMaxValue)
        {
            Debug.Log(alpha);
            alpha -= Time.deltaTime;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
        }
        else 
        {
            IsMaxValue = false;
            alpha += Time.deltaTime;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
            if(alpha >= 1)
            {
                IsMaxValue = true;
            }
        }
    }
}
