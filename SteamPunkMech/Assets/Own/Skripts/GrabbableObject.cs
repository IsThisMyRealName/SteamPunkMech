using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface GrabbableObject {


    void grab(GameObject controller);
    void move();
    void letGo();

}
