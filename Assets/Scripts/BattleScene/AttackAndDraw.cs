using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackAndDraw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(GameObject.Find("BattleManager").GetComponent<BattleManager>().Draw);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
