using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    void Start(){
   // Changes the position to x:1, y:1, z:0
 transform.position = new Vector3(1, 1, 0);
 // It is also possible to set the position with a Vector2
 // This automatically sets the Z axis to 0
 transform.position = new Vector2(1, 1);
 // Moving object on a single axis
 Vector3 newPosition = transform.position; // We store the current position
 newPosition.y = 100; // We set a axis, in this case the y axis
 transform.position = newPosition; // We pass it back
 }
 private void Update()
 {
 // We add +1 to the x axis every frame.
 // Time.deltaTime is the time it took to complete the last frame
 // The result of this is that the object moves one unit on the x axis every second
 transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
 
}
}
