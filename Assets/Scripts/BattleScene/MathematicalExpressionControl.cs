using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathematicalExpressionControl : MonoBehaviour
{
  
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
}
