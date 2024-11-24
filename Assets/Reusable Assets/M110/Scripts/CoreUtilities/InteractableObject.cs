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
    private Vector3 tablePosition; // Η θέση στην οποία τοποθετείται το αντικείμενο
    public void Target()
    {
        nearTable = true;
        tablePosition = transform.position; // Αποθηκεύει τη θέση του τραπεζιού
        targetEvent?.Invoke(); // Εκτελεί το event αν έχει οριστεί
        Debug.Log("Near table!");
    }

    public void UnTarget()
    {
        nearTable = false;
        unTargetEvent?.Invoke(); // Εκτελεί το event αν έχει οριστεί
        Debug.Log("Left table!");
    }

    
  
    private bool isHeld = false; // Ελέγχει αν ο παίκτης κρατάει το αντικείμενο
    private Vector3 originalPosition; // Αποθήκευση αρχικής θέσης

    public void GetV() => interactionEvent?.Invoke();

    public void Interact()
    {
        if (!isHeld)
        {
            // Πιάσιμο αντικειμένου
            originalPosition = transform.position;
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f; // Μπροστά από τον παίκτη
            Debug.Log("Picked up " + gameObject.name);

            isHeld = true;
        }
        else
        {
            // ’φημα αντικειμένου
            if (nearTable)
            {
                // Αν είναι κοντά στο τραπέζι, τοποθέτησέ το στη θέση του τραπεζιού
                transform.position = tablePosition;
                Debug.Log("Placed " + gameObject.name + " on the table!");
            }
            else
            {
                // Απλά άφησέ το στη θέση που είναι
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


