using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int MovementSpeed;
    [SerializeField] private float RotationSpeed;
    private UIController uc;

    private void Start()
    {
        uc = GetComponent<UIController>();
    }

    private void Update()
    {
        MoveTheHole();
    }

    private void MoveTheHole()
    {
        if (uc.IsPaused) return;
        float mm = Input.GetAxis("Vertical");
        float rt = Input.GetAxis("Horizontal");
        transform.Translate(transform.forward*mm*MovementSpeed*Time.deltaTime);
        transform.Rotate(new Vector3(0,rt,0),Space.Self);
    }
}
