using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.NewField();
        GameManager.Instance.AddScore(10);
    }
    
}
