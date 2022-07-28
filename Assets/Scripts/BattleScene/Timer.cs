using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            gameObject.GetComponent<TextMeshProUGUI>().text = ((int)time).ToString();
        }
        else
        {
            GameObject.Find("BattleManager").GetComponent<BattleManager>().PlayerHp -= 1;
            time = 30;
        }
    }

    public void TimerReset()
    {
        time = 30;
    }
}
