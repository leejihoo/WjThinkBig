using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardReward : MonoBehaviour
{
    [SerializeField]
    private GameObject[] NumberCards;
    [SerializeField]
    private GameObject[] OperatorCards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var randomNum = Random.Range(0, 9);
        var randomOp = Random.Range(0, 6);

        if (transform.childCount < 2)
        {
            var instanceNumber = GameObject.Instantiate(NumberCards[randomNum], transform);
            instanceNumber.GetComponent<CardControl>().IsCanDrag = false;
            instanceNumber.GetComponent<CardControl>().IsCanClick = true;
        }
        else if(transform.childCount == 2)
        {
            var instanceOperator = GameObject.Instantiate(OperatorCards[randomOp], transform);
            instanceOperator.GetComponent<CardControl>().IsCanDrag = false;
            instanceOperator.GetComponent<CardControl>().IsCanClick = true;
        }
    }
}
