using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    [SerializeField]private float timeDelay = 0.5f;
    [SerializeField]private bool isFalling = false;

    [SerializeField]private float speedDown;
    [Header("Destroy Platform ")]
    [SerializeField]private float deadZone = 2; 

    private void Awake() 
    {
        rb= gameObject.GetComponent<Rigidbody>();
        isFalling = false;
    }

    private void Update() 
    {
        PlatIsFalling();
        DestroyPlatform();
    }

#region event
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
        }
    }

    
#endregion

#region method
    private void PlatIsFalling()
    {
        if(isFalling)
        {
            StartCoroutine(TimeDelayOfPlat());
        }
    }


    IEnumerator TimeDelayOfPlat()
    {
        yield return new WaitForSeconds(timeDelay);
        rb.isKinematic = false;
    }

    private void DestroyPlatform()
    {
        if(transform.position.y <= -deadZone) 
        {
            Destroy(gameObject);
        }
    }
#endregion
}
