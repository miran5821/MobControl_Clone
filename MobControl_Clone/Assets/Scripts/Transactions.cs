using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Miran
{
    public class Transactions : MonoBehaviour
    {
        public static void Multiply(int incomingNumber,List<GameObject> characterList,Transform spawnPos) // çarpma
        {
            int loopCount = (GameManager.instantCharacterCount * incomingNumber) - GameManager.instantCharacterCount;
            //                        5                             6                      5     = 25     (5 + 25 = 30)(6 * 5 = 30)
            //anlýk karakter sayým 10 ve x3 geldi döngünün 20 kere dönmesi gerekir
            int number = 0;
            foreach (var item in characterList)
            {
                if (number<loopCount)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = spawnPos.position;
                        item.SetActive(true);
                        Debug.LogError(item.name);
                        number++;
                    }
                }
                else
                {
                    number = 0;
                    break;
                }
            }
            GameManager.instantCharacterCount *= incomingNumber;
        }
        public static void Collection(int incomingNumber, List<GameObject> characterList, Transform spawnPos) // toplama
        {
            int loopCount =  incomingNumber;
            //                        5                             6                      5     = 25     (5 + 25 = 30)(6 * 5 = 30)
            //anlýk karakter sayým 10 ve +3 geldi döngünün 3 kere dönmesi gerekir
            int number = 0;
            foreach (var item in characterList)
            {
                if (number < loopCount)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = spawnPos.position;
                        item.SetActive(true);
                        Debug.LogError(item.name);
                        number++;
                    }
                }
                else
                {
                    number = 0;
                    break;
                }
            }
            GameManager.instantCharacterCount += incomingNumber;
        }
        public static void Divide(int incomingNumber, List<GameObject> characterList) // bölme
        {
            if (GameManager.instantCharacterCount < incomingNumber)
            {
                foreach (var item in characterList)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.instantCharacterCount = 1;
            }
            else
            {
                int dividing = GameManager.instantCharacterCount / incomingNumber;
                int number = 0;
                foreach (var item in characterList)
                {
                    if (number != dividing)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            number++;
                        }
                    }
                    else
                    {
                        number = 0;
                        break;
                    }
                }
                if (GameManager.instantCharacterCount %incomingNumber ==0)
                {
                    GameManager.instantCharacterCount /= incomingNumber;
                }
                else
                {
                    GameManager.instantCharacterCount /= incomingNumber;
                    GameManager.instantCharacterCount++; // 11 / 3 = 3 alacak fakat 4 e yakýn 
                }
            }
        }
        public static void Extraction(int incomingNumber, List<GameObject> characterList) // çýkarma
        {
            if (GameManager.instantCharacterCount < incomingNumber)
            {
                foreach (var item in characterList)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManager.instantCharacterCount =1;
            }
            else
            {
                int number = 0;
                foreach (var item in characterList)
                {
                    if(number != incomingNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            number++;
                        }
                    }
                    else
                    {
                        number = 0;
                        break;
                    }
                }
                GameManager.instantCharacterCount -= incomingNumber;
            }
            
        }

    }

}
