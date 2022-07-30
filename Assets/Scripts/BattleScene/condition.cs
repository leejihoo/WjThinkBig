using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class condition : MonoBehaviour
{
    string Problem;
    // Start is called before the first frame update
    void Start()
    {
        Problem = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().condition.ToString() + " 보다 크거나 같다.";
        gameObject.GetComponent<TextMeshProUGUI>().text = Problem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
