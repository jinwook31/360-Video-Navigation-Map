using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testforcam : MonoBehaviour{
    private Vector3 previous_m;
    private Transform trans;

    void Start() {
        trans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        float delta_angle_x, delta_angle_y;

        if (Input.GetMouseButton(0)){
            delta_angle_x = Input.mousePosition.x - previous_m.x;
            delta_angle_y = Input.mousePosition.y - previous_m.y;
            transform.Rotate(new Vector3(-delta_angle_y, delta_angle_x, 0));

            Vector3 eulerRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
        }

        previous_m = Input.mousePosition;
    }
}
