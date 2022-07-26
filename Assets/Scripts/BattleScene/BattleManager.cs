using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    private int CurrentFloor;
    private int CurrentTurn;

    public BattleManager()
    {
        CurrentFloor = 1;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = new BattleManager();
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageRenew();
    }

    void StageRenew()
    {
        if(GameObject.Find("Stage") != null)
        {
            GameObject.Find("Stage").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CurrentFloor + "Ãþ";
        }
    }
}
