using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public int CurrentFloor;
    private int CurrentTurn;
    private int MaxHandNumberCard;
    private int MaxHandOperatorCard;
    public int PlayerHp;
    public Sprite[] ReStartImage;
    public AudioClip[] ReStartSound;
    public bool PlayerIsDead;
    public BattleManager()
    {
        CurrentFloor = 1;
        CurrentTurn = 1;
        MaxHandNumberCard = 3;
        MaxHandOperatorCard = 2;
        PlayerIsDead = false;
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
        PlayerHp = 3;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Suffle(GameObject.Find("NumberCardDeck"));
        Suffle(GameObject.Find("OperatorCardDeck"));
        Draw();

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "BattleScene")
        {
            StageRenew();
            PlayerHpReNew();
        }
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
        GameObject.Find("cardSuffleSound").GetComponent<AudioSource>().Play();
        for (int i = 0; i<30; i++)
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
        Debug.Log("ÀÛµ¿");
        CurrentFloor += 1;
        CurrentTurn = 1;
        if(CurrentFloor >= 11)
        {
            GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetComponent<AudioSource>().clip = ReStartSound[1];
            GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetChild(0).GetComponent<Image>().sprite = ReStartImage[1];
            GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetChild(0).GetComponent<Image>().SetNativeSize();
        }
        else
        {
            Loading.LoadScene("BattleScene");
        }

    }

    public void PlayerHpReNew()
    {
        if(GameObject.Find("CharaterHearts").transform.childCount > PlayerHp && GameObject.Find("CharaterHearts").transform.childCount > 0)
        {
            int count = GameObject.Find("CharaterHearts").transform.childCount - PlayerHp;
            
            for(int i = 0; i<count; i++)
            {
                Destroy(GameObject.Find("CharaterHearts").transform.GetChild(0).gameObject);
            }

        }
        else
        {
            if (!PlayerIsDead && PlayerHp <= 0)
            {
                GameObject.Find("Enemy").SetActive(false);
                GameObject.Find("Player").SetActive(false);
                GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetComponent<AudioSource>().clip = ReStartSound[0];
                GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetChild(0).GetComponent<Image>().sprite = ReStartImage[0];
                GameObject.Find("Canvas").transform.GetChild(GameObject.Find("Canvas").transform.childCount - 1).GetChild(0).GetComponent<Image>().SetNativeSize();
                PlayerIsDead = true;
            }

        }
        
    }

}
