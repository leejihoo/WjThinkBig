using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStartBtn : MonoBehaviour
{
    public void ClickStartBtn()
    {
        SceneManager.LoadScene("BattleScene");
    }
}