using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaChamVatThe : MonoBehaviour
{
    [SerializeField] private AudioSource grassSound;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Grass"))
        {
            grassSound.Play();
        }
    }
}
