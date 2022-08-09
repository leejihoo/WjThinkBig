using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reStart : MonoBehaviour
{
    public void RestartBtn()
    {
        Destroy(GameObject.Find("BattleManager"));
        Destroy(GameObject.Find("NumberCardDeck"));
        Destroy(GameObject.Find("OperatorCardDeck"));
        Loading.LoadScene("GameStartScene");
    }
}
