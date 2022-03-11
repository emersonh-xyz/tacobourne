using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public GameObject player;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < 90 || rotationZ > 90) // If arm is on the other side of the body
        {
            if (player.transform.eulerAngles.y <= 0)// If player is facing to the right
            {
                
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ); // Flip the arm on the x axis

            } else if (player.transform.eulerAngles.y >= 180) // if player is facing to the left
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ); 
            }
        }
     }
}
