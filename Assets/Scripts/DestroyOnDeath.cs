using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }



}