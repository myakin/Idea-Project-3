using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IdeaProject3;

public class PlayerController : MonoBehaviour {
    public PlayerEvents playerEvents;
    public float antiGravityForceMagnitude = 10;
    public bool isDead;

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private string currentScene;

    private void OnDestroy() {
        GameManager.instance.UnloadMainUI();
    }

    private void Start() {
        GameManager.instance.player = gameObject;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene().name;
        GameManager.instance.GenerateSceneCompositionObject();
        GameManager.instance.LoadMainUI(playerEvents);
    }

    private void Update() {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("Wings", true);
                rigidbody.AddForce(Vector3.up * antiGravityForceMagnitude, ForceMode2D.Impulse);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("Wings",false);
            }
        }
        if (isDead)
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene(currentScene);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            isDead = true;
            animator.SetBool("DeadNotBigSoupRice", true);
        }
    }
}