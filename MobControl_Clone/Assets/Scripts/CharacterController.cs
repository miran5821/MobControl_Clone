using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Singleton<CharacterController>
{
    float firstClickXMousePos;
    float firstClickXPosition;
    public float horizontalMoveSpeed;
    public float floorXLength;
    public float forwardSpeed;
    bool isController = true;
    Vector3 inputMousePos;
    int oldTouchCount;
    bool isDownButton;

    [SerializeField] GameObject endGamePanel;
    void Update()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && isController)
        {
            isDownButton = true;
            oldTouchCount = 1;
            SetMousePos();
            SetFirstMousePos();
        }
        if (Input.GetMouseButton(0) && isDownButton)
        {
            SetMousePos();
            float newXPos = Mathf.Lerp(transform.position.x, (firstClickXPosition + (MouseXPos() - firstClickXMousePos) * horizontalMoveSpeed), Time.deltaTime * 20);
            if (Mathf.Abs(newXPos - transform.position.x) >= .01f)
            {
                float changeXPos = newXPos - transform.position.x;
                if (changeXPos != 0)
                {
                    if (changeXPos > 0 && newXPos < floorXLength)
                        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
                    else if (changeXPos < 0 && newXPos > -floorXLength)
                        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
                    else
                        SetFirstMousePos();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
            isDownButton = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collection") || other.gameObject.CompareTag("Divide") || other.gameObject.CompareTag("Extraction") || other.gameObject.CompareTag("Multiply"))
        {

            int index = int.Parse(other.name);

            GameManager.Instance.CreatMob(other.tag, index, other.transform);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            endGamePanel.SetActive(true);
        }
    }
    void SetMousePos()
    {
#if UNITY_EDITOR
        inputMousePos = Input.mousePosition;
#else
        inputMousePos = Input.GetTouch(0).position;
        if (oldTouchCount != Input.touchCount)
        {
            oldTouchCount = Input.touchCount;
            SetFirstMousePos();
        }
#endif
    }
    void SetFirstMousePos()
    {
        firstClickXMousePos = MouseXPos();
        firstClickXPosition = transform.position.x;
    }
    float MouseXPos()
    {
        return Remap(inputMousePos.x, 0, Screen.width, 0, 1);
    }
    public void SetIsController(bool value)
    {
        isController = value;
    }
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        float result = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        return result;
    }
}
