using System;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerSpeed;
    private int points = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    public void IncreasePoints()
    {
        points++;
    }
}
