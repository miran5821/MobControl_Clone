using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Miran;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Transform targetPoint;
    public List<GameObject> characterList;
    public static int instantCharacterCount=1; // anlýk karakter sayýsý
    public GameObject stain;
    [SerializeField] GameObject startPanel;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        Debug.Log(instantCharacterCount);
            
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void CreatMob(string operationType,int incomingNumber, Transform spawnPos)
    {
        switch (operationType)
        {
            case "Multiply":
               Transactions.Multiply(incomingNumber, characterList, spawnPos);
                break;
            case "Collection":
                Transactions.Collection(incomingNumber, characterList, spawnPos);
                break;
            case "Extraction":
                Transactions.Extraction(incomingNumber, characterList);
                break;
            case "Divide":
                Transactions.Divide(incomingNumber, characterList);
                break;
        }
    }
}
