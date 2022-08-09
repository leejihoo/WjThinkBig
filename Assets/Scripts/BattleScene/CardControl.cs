using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static CardType;
public class CardControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    bool IsCardInMathematicalExpression;
    Vector3 returnPosition;
    public CardTypes cardType;
    public string CardValue;
    public bool IsCanDrag;
    public bool IsCanClick;

    public CardControl()
    {
        IsCanDrag = true;
        IsCanClick = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject.Find("cardSelectSound").GetComponent<AudioSource>().Play();
        returnPosition = gameObject.transform.position;
        gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsCanDrag)
        {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1f));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (IsCardInMathematicalExpression )
        {
            var MathematicalExpression = GameObject.Find("MathematicalExpression");
            if((MathematicalExpression.transform.childCount > 0 && MathematicalExpression.transform.GetChild(MathematicalExpression.transform.childCount -1).GetComponent<CardControl>().cardType != cardType) || (MathematicalExpression.transform.childCount == 0 && cardType == CardTypes.NUMBER))
            {
                if (IsCanDrag)
                {
                    GameObject.Find("cardPlaceSound").GetComponent<AudioSource>().Play();
                    gameObject.transform.SetParent(MathematicalExpression.transform);
                    returnPosition = gameObject.transform.position;
                }
                
            }

        }

        this.transform.position = returnPosition;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsCanClick)
        {
            if(cardType == CardTypes.NUMBER)
            {
                transform.parent = GameObject.Find("NumberCardDeck").transform;
            }
            else
            {
                transform.parent = GameObject.Find("OperatorCardDeck").transform;
            }
            IsCanDrag = true;
            IsCanClick = false;
            GameObject.Find("BattleManager").GetComponent<BattleManager>().MoveNextFloor();
        }
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
        if(collision.name == "MathematicalExpression")
            IsCardInMathematicalExpression = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "MathematicalExpression")
            IsCardInMathematicalExpression = false;
    }

    
}
