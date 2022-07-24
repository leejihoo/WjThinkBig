using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static CardType;
public class CardControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    bool IsCardInMathematicalExpression;
    Vector3 returnPosition;
    [SerializeField]
    private CardTypes cardType; 

    public void OnBeginDrag(PointerEventData eventData)
    {
        returnPosition = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(IsCardInMathematicalExpression);

        if (IsCardInMathematicalExpression)
        {
            var MathematicalExpression = GameObject.Find("MathematicalExpression");
            gameObject.transform.SetParent(MathematicalExpression.transform);
            returnPosition = gameObject.transform.position;
        }

        this.transform.position = returnPosition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            if (cardType == CardTypes.NUMBER)
            {
                var NumberCardGroup = GameObject.Find("NumberCardGroup");
                gameObject.transform.SetParent(NumberCardGroup.transform);
                returnPosition = gameObject.transform.position;
            }
            else if (cardType == CardTypes.OPERATOR)
            {
                var OperatorCardGroup = GameObject.Find("OperatorCardGroup");
                gameObject.transform.SetParent(OperatorCardGroup.transform);
                returnPosition = gameObject.transform.position;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("╣И╬Н©сю╫");
        if(collision.name == "MathematicalExpression")
            IsCardInMathematicalExpression = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "MathematicalExpression")
            IsCardInMathematicalExpression = false;
    }
}
