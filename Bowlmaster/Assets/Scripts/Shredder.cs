using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    void OnTriggerExit(Collider other) {
        
        if (other.name == "Ball") {
            return;
        }
        
        if (other.transform.parent.GetComponent<Pin>()) {
            // Debug.Log(other.transform.parent.name + " no longer in pin setter");
            Destroy(other.transform.parent.gameObject);
        }
    }
}
