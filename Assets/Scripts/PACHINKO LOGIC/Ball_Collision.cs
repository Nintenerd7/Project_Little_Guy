using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSourceController.Instance.PlaySFX("Plonk");// plays the plonk noise
    }
}
