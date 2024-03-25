using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] private float speedMov;
    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(inputX, inputY, 0) * (speedMov * Time.deltaTime);

        /*
        if (inputY > 0)
        {
            animator.SetBool("Up", true);
        }
        else if (inputY < 0)
        {
            animator.SetBool("Down", true);
        }
        else if (inputX < 0)
        {
            animator.SetBool("Left", true);
        }
        else if (inputX > 0)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        */
    }
}