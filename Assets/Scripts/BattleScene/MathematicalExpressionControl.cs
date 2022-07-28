using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;

public class MathematicalExpressionControl : MonoBehaviour
{
    string DamageExpression;
    private DataTable dataTable;
    int Damage;

    public MathematicalExpressionControl()
    {
        dataTable = new DataTable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ResetBtn()
    {
        transform.DetachChildren();
    }

    public void BackspaceBtn()
    {
        if(transform.childCount > 0)
            transform.GetChild(transform.childCount-1).transform.parent = null;
    }

    public void AttackBtn()
    {
        if(transform.childCount > 0)
        {
            // 수식의 마지막 카드가 숫자 카드일 경우
            if (transform.GetChild(transform.childCount - 1).GetComponent<CardControl>().cardType == CardType.CardTypes.NUMBER)
            {
                DamageExpression = "";
                Damage = 0;
                foreach (Transform Card in transform)
                {
                    DamageExpression += Card.GetComponent<CardControl>().CardValue;
                }
                Damage = Convert.ToInt32(dataTable.Compute(DamageExpression, ""));
                GameObject.Find("EnemyHp").GetComponent<EnemyHpControl>().CurrentHp -= Damage;
                GameObject.Find("Timer").GetComponent<Timer>().TimerReset();
                SendToTomb();
            }
        }

    }

    void SendToTomb()
    {
        var cardCount = transform.childCount;
        for (int i = 0; i< cardCount; i++)
        {
            if(transform.GetChild(transform.childCount - 1).GetComponent<CardControl>().cardType == CardType.CardTypes.NUMBER)
            {
                transform.GetChild(transform.childCount - 1).parent = GameObject.Find("NumberCardTomb").transform;
            }
            else
            {
                transform.GetChild(transform.childCount - 1).parent = GameObject.Find("OperatorCardTomb").transform;
            }
        }
    }
}
