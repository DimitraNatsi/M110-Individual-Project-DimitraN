using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
 
    [SerializeField]
    UnityEvent interactionEvent;
    [SerializeField]
    UnityEvent targetEvent;
    [SerializeField]
    UnityEvent unTargetEvent;

    private bool nearTable = false;
    private Vector3 tablePosition; // � ���� ���� ����� ������������ �� �����������
    public void Target()
    {
        nearTable = true;
        tablePosition = transform.position; // ���������� �� ���� ��� ���������
        targetEvent?.Invoke(); // ������� �� event �� ���� �������
        Debug.Log("Near table!");
    }

    public void UnTarget()
    {
        nearTable = false;
        unTargetEvent?.Invoke(); // ������� �� event �� ���� �������
        Debug.Log("Left table!");
    }

    
  
    private bool isHeld = false; // ������� �� � ������� ������� �� �����������
    private Vector3 originalPosition; // ���������� ������� �����

    public void GetV() => interactionEvent?.Invoke();

    public void Interact()
    {
        if (!isHeld)
        {
            // ������� ������������
            originalPosition = transform.position;
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f; // ������� ��� ��� ������
            Debug.Log("Picked up " + gameObject.name);

            isHeld = true;
        }
        else
        {
            // ����� ������������
            if (nearTable)
            {
                // �� ����� ����� ��� �������, ���������� �� ��� ���� ��� ���������
                transform.position = tablePosition;
                Debug.Log("Placed " + gameObject.name + " on the table!");
            }
            else
            {
                // ���� ����� �� ��� ���� ��� �����
                Debug.Log("Dropped " + gameObject.name);
            }

            isHeld = false;
        }

        interactionEvent?.Invoke();
    }



#region examples


public void OnPickUp()
    {
        Debug.Log(gameObject.name + " picked up!");
        // You can either disable or destroy the object
        gameObject.SetActive(false);
        //add to inventory?
    }

    


    #endregion
}


