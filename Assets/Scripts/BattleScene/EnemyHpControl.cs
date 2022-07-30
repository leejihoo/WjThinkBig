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

        var NCTcount = GameObject.Find("NumberCardTomb").transform.childCount;
        for (int i = 0; i < NCTcount; i++)
        {
            GameObject.Find("NumberCardTomb").transform.GetChild(GameObject.Find("NumberCardTomb").transform.childCount - 1).parent = GameObject.Find("NumberCardDeck").transform;
        }

        var OCTcount = GameObject.Find("OperatorCardTomb").transform.childCount;
        for (int i = 0; i < OCTcount; i++)
        {
            GameObject.Find("OperatorCardTomb").transform.GetChild(GameObject.Find("OperatorCardTomb").transform.childCount - 1).parent = GameObject.Find("OperatorCardDeck").transform;
        }

        var NCGcount = GameObject.Find("NumberCardGroup").transform.childCount;
        for (int i = 0; i< NCGcount; i++)
        {
            Debug.Log("숫자 덱으로 돌아가는중");
            GameObject.Find("NumberCardGroup").transform.GetChild(GameObject.Find("NumberCardGroup").transform.childCount - 1).parent = GameObject.Find("NumberCardDeck").transform;
        }

        var OCGcount = GameObject.Find("OperatorCardGroup").transform.childCount;
        for (int i = 0; i < OCGcount; i++)
        {
            Debug.Log("연산자 덱으로 돌아가는중");
            GameObject.Find("OperatorCardGroup").transform.GetChild(GameObject.Find("OperatorCardGroup").transform.childCount - 1).parent = GameObject.Find("OperatorCardDeck").transform;
        }
    }
}
