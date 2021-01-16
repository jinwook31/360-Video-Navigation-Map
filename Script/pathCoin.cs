using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pathCoin : MonoBehaviour{
    private Image coin;

    // Start is called before the first frame update
    void Start(){
        coin = GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        coin.enabled = false;
    }
}
