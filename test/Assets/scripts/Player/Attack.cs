using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Collider2D myCollider;
    private bool isAttacking = false;
    private Vector3 originalScale;
    private Vector3 originalPosition; // Store the original position of the collider

    private Transform playerTransform; // Declare the playerTransform variable

      private Animator _animator;

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        originalScale = myCollider.transform.localScale;
        originalPosition = myCollider.transform.position;


         GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject parentObject = transform.parent.gameObject; // Get the parent object

        // Find the Animator component in the parent object
        _animator = parentObject.GetComponent<Animator>();

    if (playerObject != null)
    {
        playerTransform = playerObject.transform;
    }
    else
    {
        Debug.LogError("Player GameObject not found. Make sure it's tagged as 'Player'.");
    }
}

 private void StartAttack()
    {
        isAttacking = true;
        // Trigger the animation to play
        _animator.SetTrigger("protagonistAttack.anim");
    }
    

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            EnlargeCollider();
            StartAttack();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isAttacking = false;
            ResetCollider();
        }
    }

    private void EnlargeCollider()
    {
        float scaleFactorX = 4.0f;
        float scaleFactorY = 2.0f;

        Vector3 newScale = new Vector3(originalScale.x * scaleFactorX, originalScale.y * scaleFactorY, originalScale.z);
        myCollider.transform.localScale = newScale;
    }

    private void ResetCollider()
{
    // Reset the collider's scale to the original scale
    myCollider.transform.localScale = originalScale;

    // Reset the collider's position to the player's position
    myCollider.transform.position = playerTransform.position;
}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
