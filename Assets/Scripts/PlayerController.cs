using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        
        animator.SetFloat("xInput",Mathf.Abs(xInput));

        Vector3 scale = transform.localScale;
        if(xInput<0)
        {
            scale.x = -1f*Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        transform.Translate(xInput*speed*Time.deltaTime, 0, 0);

    }
}
