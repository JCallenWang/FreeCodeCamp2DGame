using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    //Create Variable
    public float MoveSpeed = 10;
    public float JumpForce = 10;
    float movementX;


    //Create component-type function
    Rigidbody2D mybody;
    SpriteRenderer sr;
    Animator anim;
    GameObject Button;


    string walk_animation = "Walk";             //set to the parameter in animator
    string ground_tag = "Ground";
    bool isGrounded = true;

    string enemy_tag = "Enemy";
    string Died_animation = "IsDied";
    public bool InPutEnable = true;
    

    private void Awake()
    {
        //Set variable to attached component
        mybody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Button = GameObject.Find("Button");
        Button.SetActive(false);
    }
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }
   
    void PlayerMoveKeyboard()
    {
        if (InPutEnable)
        {
            movementX = Input.GetAxisRaw("Horizontal");
            //object's position = current position + new vector * deltaTime * variable
            //deltaTime means change [execute <FPS> time] to [one time when calling] 
            transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * MoveSpeed;
        }
        
    }

    void AnimatePlayer()
    {
        //moving to right side(Positive)
        if (movementX > 0 && InPutEnable)
        {
            sr.flipX = false;
            anim.SetBool(walk_animation, true);
        }
        //moving to left side(negative)
        else if (movementX < 0 && InPutEnable)
        {
            sr.flipX = true;
            anim.SetBool(walk_animation, true);
        }
        //not moving
        else
        {
            anim.SetBool(walk_animation, false);
        }
    }
    
    void PlayerJump()
    {
        //GetButtonDown 按下與放開算一次, GetButton只要按到都算
        if (Input.GetButton("Jump") && isGrounded && InPutEnable)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    //Collision碰撞(Component<Collider> gameObject.name)
    public void OnCollisionEnter2D(Collision2D other)
    {
        //jumping check
        if (other.gameObject.CompareTag(ground_tag))
        {
            isGrounded = true;
        }

        //Enemy touch check
        if (other.gameObject.CompareTag(enemy_tag))
        {
            Destroy(gameObject,2f);
            InPutEnable = false;
            Button.SetActive(true);
            anim.SetBool(Died_animation, true);
        }
    }

}//class
