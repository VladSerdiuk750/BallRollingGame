using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Animator anim;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingBall();
    }

    public void BonusReceived()
    {
        anim.SetBool("IsPicked", true);
        Invoke("TurnOffBonus", 1f);
    }

    private void MovingBall()
    {
        _rigidbody.velocity = new Vector3(speed, 0, 0);
    }

    public void MoveToSide(Vector3 side)
    {
        var previousPosition = transform.position;
        var zPosition = (int)previousPosition.z;
        if (zPosition == -4 && (int)side.z == -2)
        {
            return;
        }

        if (zPosition == 4 && (int) side.z == 2)
        {
            return;
        }

        zPosition += (int)side.z;
        
        transform.position = new Vector3(previousPosition.x, previousPosition.y, zPosition);
    }

    public void TurnOffBonus()
    {
        anim.SetBool("IsPicked", false);
    }
}
