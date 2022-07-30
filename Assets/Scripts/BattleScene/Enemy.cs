using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string Name;
    public int Hp;
    public int condition;

    private void Awake()
    {
        Hp += 10 * GameObject.Find("BattleManager").GetComponent<BattleManager>().CurrentFloor;
        condition = Random.Range(1, GameObject.Find("BattleManager").GetComponent<BattleManager>().CurrentFloor);
    }
}
