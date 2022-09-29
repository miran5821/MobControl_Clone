using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharacter : MonoBehaviour
{
    Transform target;
    NavMeshAgent navMeshAgent;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameManager.Instance.targetPoint;
    }

    private void LateUpdate()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instantCharacterCount--;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Hammer"))
        {
            GameManager.instantCharacterCount--;
            gameObject.SetActive(false);
            GameObject stain = Instantiate(GameManager.Instance.stain, new Vector3(transform.position.x,0.02f,transform.position.z),Quaternion.Euler(new Vector3( 90,0,0)));
            Destroy(stain, 5f);
        }
    }
}
