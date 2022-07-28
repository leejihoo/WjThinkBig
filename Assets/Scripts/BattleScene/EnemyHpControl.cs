using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHpControl : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHp;
    public bool EnemyIsDead;
    public EnemyHpControl()
    {
        EnemyIsDead = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().Hp;
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp > 0)
        {
            gameObject.GetComponent<Slider>().value = (float)CurrentHp / MaxHp;
            gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<TextMeshProUGUI>().text = CurrentHp + "/" + MaxHp;
        }
        else
        {
            if (EnemyIsDead)
            {
                CurrentHp = 0;
                gameObject.GetComponent<Slider>().value = (float)CurrentHp / MaxHp;
                gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<TextMeshProUGUI>().text = CurrentHp + "/" + MaxHp;
                BackToDeck();
                GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 2).gameObject.SetActive(true);
                GameObject.Find("Enemy").SetActive(false);
                GameObject.Find("Player").SetActive(false);
                EnemyIsDead = false;
            }
        }
    }

    public void BackToDeck()
    {
        GameObject.Find("NumberCardTomb").transform.DetachChildren();
        GameObject.Find("OperatorCardTomb").transform.DetachChildren();

        var NCGcount = GameObject.Find("NumberCardGroup").transform.childCount;
        for (int i = 0; i< NCGcount; i++)
        {
            GameObject.Find("NumberCardGroup").transform.GetChild(GameObject.Find("NumberCardGroup").transform.childCount - 1).parent = GameObject.Find("NumberCardDeck").transform;
        }

        var OCGcount = GameObject.Find("OperatorCardGroup").transform.childCount;
        for (int i = 0; i < OCGcount; i++)
        {
            GameObject.Find("OperatorCardGroup").transform.GetChild(GameObject.Find("OperatorCardGroup").transform.childCount - 1).parent = GameObject.Find("OperatorCardDeck").transform;
        }
    }
}
