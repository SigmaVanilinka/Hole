using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    // Start is called before the first frame update
    private void MoveTheHole()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation.y+=1f;
        }
    }
}
