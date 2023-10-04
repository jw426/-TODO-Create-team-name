using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromptScript : MonoBehaviour
{

    [SerializeField] GameObject customer; 
    [SerializeField] GameObject prompt; 
    // Start is called before the first frame update
    void onClick() {
        customer.SetActive(false);
        prompt.SetActive(true);
    }

}
