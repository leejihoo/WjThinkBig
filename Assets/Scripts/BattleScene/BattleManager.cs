using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public int CurrentFloor;
    private int CurrentTurn;
    private int MaxHandNumberCard;
    private int MaxHandOperatorCard;
    public int PlayerHp;

    public BattleManager()
    {
        CurrentFloor = 1;
        CurrentTurn = 1;
        MaxHandNumberCard = 3;
        MaxHandOperatorCard = 2;
        PlayerHp = 3;
    }

    private void Awake()
    {
        KeepObject();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Suffle(GameObject.Find("NumberCardDeck"));
        Draw();
    }

    // Update is called once per frame
    void Update()
    {
        StageRenew();
        PlayerHpReNew();
    }

    void StageRenew()
    {
        if(GameObject.Find("Stage") != null)
        {
            GameObject.Find("Stage").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CurrentFloor + "Ãþ";
        }
    }

    void KeepObject()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Suffle(GameObject Deck)
    {
        var cardCount = Deck.transform.childCount;     
        
        for(int i = 0; i<30; i++)
        {
            
            var firstRandomNumber = Random.Range(0, cardCount);
            var secondRandomNumber = Random.Range(0, cardCount);
            Debug.Log(firstRandomNumber);

            Deck.transform.GetChild(firstRandomNumber).SetSiblingIndex(secondRandomNumber);
            //Deck.transform.GetChild(secondRandomNumber).SetSiblingIndex(firstRandomNumber);
        }

    }

    public void Draw()
    {
        var NCD = GameObject.Find("NumberCardDeck");
        var OCD = GameObject.Find("OperatorCardDeck");
        var NCG = GameObject.Find("NumberCardGroup");
        var OCG = GameObject.Find("OperatorCardGroup");
        var NCT = GameObject.Find("NumberCardTomb");
        var OCT = GameObject.Find("OperatorCardTomb");

        if (NCG.transform.childCount < MaxHandNumberCard)
        {
            var drawCount = MaxHandNumberCard - NCG.transform.childCount;

            if(NCD.transform.childCount >= drawCount)
            {
                for(int i = 0; i<drawCount; i++)
                {
                    NCD.transform.GetChild(NCD.transform.childCount - 1).parent = NCG.transform;
                }
            }
            else if(NCD.transform.childCount < drawCount && NCD.transform.childCount > 0)
            {
                drawCount = NCD.transform.childCount;

                for (int i = 0; i < drawCount; i++)
                {
                    NCD.transform.GetChild(NCD.transform.childCount - 1).parent = NCG.transform;
                }
            }
            else
            {
                var cardCount = NCT.transform.childCount;

                for (int i = 0; i< cardCount; i++)
                {
                    NCT.transform.GetChild(NCT.transform.childCount - 1).parent = NCD.transform;
                }

                Suffle(NCD);

                for (int i = 0; i < drawCount; i++)
                {
                    NCD.transform.GetChild(NCD.transform.childCount - 1).parent = NCG.transform;
                }
            }
        }

        if (OCG.transform.childCount < MaxHandOperatorCard)
        {
            var drawCount = MaxHandOperatorCard - OCG.transform.childCount;

            if (OCD.transform.childCount >= drawCount)
            {
                for (int i = 0; i < drawCount; i++)
                {
                    OCD.transform.GetChild(OCD.transform.childCount - 1).parent = OCG.transform;
                }
            }
            else if (OCD.transform.childCount < drawCount && OCD.transform.childCount > 0)
            {
                drawCount = OCD.transform.childCount;

                for (int i = 0; i < drawCount; i++)
                {
                    OCD.transform.GetChild(OCD.transform.childCount - 1).parent = OCG.transform;
                }
            }
            else
            {
                var cardCount = OCT.transform.childCount;

                for (int i = 0; i < cardCount; i++)
                {
                    OCT.transform.GetChild(OCT.transform.childCount - 1).parent = OCD.transform;
                }

                Suffle(OCD);

                for (int i = 0; i < drawCount; i++)
                {
                    OCD.transform.GetChild(OCD.transform.childCount - 1).parent = OCG.transform;
                }
            }
        }
    }

    public void MoveNextFloor()
    {
        Loading.LoadScene("BattleScene");
        CurrentFloor += 1;
        CurrentTurn = 1;
    }

    public void PlayerHpReNew()
    {
        if(GameObject.Find("CharaterHearts").transform.childCount > PlayerHp && PlayerHp > 0)
        {
            int count = GameObject.Find("CharaterHearts").transform.childCount - PlayerHp;
            
            for(int i = 0; i<count; i++)
            {
                Destroy(GameObject.Find("CharaterHearts").transform.GetChild(0).gameObject);
            }

        }
        
    }
}
