using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface GrabbableObject {

    void grab(GameObject controller);
    void move(GameObject controller);
    void letGo(Vector3 velocity);

}
