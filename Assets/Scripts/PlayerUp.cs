using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制人物移动的类
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerUp : PlayerController
{
    [Header("爬坡高度")]
    [Range(0, 0.7f)]
    public float climbingHeight;
    [Range(0.001f, 0.1f)]
    public float climbingLowestHeight;
    [Header("重力加速度")]
    [SerializeField]
    protected float g;
    [SerializeField] private float jumpSpeed;
    protected bool isGround = false;

    public bool GodMode = true;
    /// <summary>
    /// 当前接触地板数量
    /// </summary>
    private int cGroundNum = 0;
    private bool climbing = false;

    //能量
    [Header("背后贴图")]
    public Texture[] energyTexture;
    public Renderer energyRenderer;
    public int energy;
    

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;
        float h = point.y - transform.position.y;
        //print("enter,tag:" + collision.collider.tag + "h:" + h);
        //如果踩到地板
        if (collision.collider.tag == "Ground" && h < climbingHeight)
        {
            cGroundNum++;
            //print("cGroundNum:" + cGroundNum);
            collision.collider.tag = "TouchedGround";
            isGround = true;
            if (!climbing)
            {
                animator.SetBool("isGround", true);
                GetComponent<ParticleSystem>().Play();
            }
            //if (h > climbingLowestHeight) climbing = true;
            ySpeed = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //print("exit,tag:"+ collision.collider.tag);
        if (collision.collider.tag == "TouchedGround")
        {
            collision.collider.tag = "Ground";
            cGroundNum--;
            //print("cGroundNum:" + cGroundNum);
            if (cGroundNum <= 0)
            {
                isGround = false;
                if (!climbing)
                {
                    animator.SetBool("isGround", false);
                    GetComponent<ParticleSystem>().Stop();
                }
                else
                {
                    //print("结束");
                    climbing = false;
                }
            }
        }
    }


    protected override void KeyBoardInput()
    {
        base.KeyBoardInput();
        if (GameSystem.InputKeys.Jump()) Jump();
    }

    private void Jump()
    {
        if (isGround || GodMode)
        {
            climbing = false;
            ySpeed = jumpSpeed;
        }
    }
    // 爬行方向
    Vector3 climbVXY = Vector3.forward;
    float climbY = 0;
    public float modeHeight;
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint c in collision.contacts)
        {
            if (cGroundNum <= 0) return;
            float h = c.point.y - transform.position.y;
            if (h < climbingHeight && h > climbingLowestHeight)
            {
                Vector3 to = c.point - transform.position - new Vector3(0, modeHeight, 0);
                climbVXY = Vector3.Cross(Vector3.Cross(to, Vector3.up), to);
                climbY = climbVXY.y;
                climbVXY.y = 0;
                float m = climbVXY.magnitude;
                climbVXY /= m;
                climbY /= m;
                if (!climbing)
                {
                    climbing = true;
                    //print("开始");
                    //print("start,tag:" + collision.collider.tag + "h:" + h);
                }
                //print("CXY:" + climbVXY + ";CY:" + climbY);
                return;
            }
        }
        //if (climbing) print("结束");
        climbing = false;
    }
    protected override void MoveY(Vector3 dirXY)
    {
        if (!isGround && ySpeed > -8)
        {
            ySpeed -= g * Time.deltaTime;
        }
        else if (climbing)
        {
            float dot = Vector3.Dot(climbVXY, dirXY);
            if (dot > 0)
            {
                //上楼
                ySpeed = dot * climbY;
                //print("dot: " + dot + ";y:" + climbY + ";ySpeed:" + ySpeed);
            }
            //else if (climbY > 1)
            //{
            //    // 下滑
            //    dirXY = -climbVXY;
            //    ySpeed = -speed;
            //}
        }
    }

    [ContextMenu("能量增加")]
    public void AddEnergy()
    {
        GameSystem.EnergyUp();
    }
    [ContextMenu("能量减少")]
    public void SubEnergy()
    {
        GameSystem.EnergyDown();
    }
    private void Start()
    {
        GameSystem.playerUp = this;
        GameSystem.flushEnergy();
    }
}
