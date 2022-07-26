using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHpControl : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHp;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().Hp;
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().value = (float) CurrentHp / MaxHp;
        gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<TextMeshProUGUI>().text = CurrentHp + "/" + MaxHp;
    }

    
}
