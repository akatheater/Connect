using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制人物移动的类
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("【人物组件】")]
    [Header("速度")]
    [SerializeField]
    protected float speed;
    protected float ySpeed;
    [Header("转弯平滑度")]
    [SerializeField]
    [Range(0.05f, 0.95f)]
    protected float smoothness;
    protected Animator animator;
    [HideInInspector]
    public Vector3 dir;
    public BuffDelegate Buff;
    [HideInInspector]
    public bool active = true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        KeyBoardInput();
    }

    protected virtual void KeyBoardInput()
    {
        if (!active)
        {
            Move(0, 0);
            return;
        }
        float h = GameSystem.InputKeys.Horizontal();
        float v = GameSystem.InputKeys.Vertical();
        Move(h, v);
    }


    protected void Move(float h, float v)
    {
        Vector3 dirXY;
        float vXY = 0;


        Vector3 right = Camera.main.transform.right;//右方单位矢量
        Vector3 foward = Quaternion.AngleAxis(-90, Vector3.up) * right;//前方单位矢量
        dirXY = right * h * speed + foward * v * speed;//平面速度矢量
        vXY = dirXY.sqrMagnitude;
        animator.SetFloat("v", vXY);

        MoveY(dirXY);

        dir = dirXY + Vector3.up * ySpeed;//最终速度矢量
        Debug.DrawLine(transform.position, transform.position + dir);
        //特殊状态
        if (Buff != null) Buff(this);

        if (vXY > 0.2f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirXY, Vector3.up), 1 - smoothness);
        }
        GetComponent<Rigidbody>().velocity = dir;
    }
    protected virtual void MoveY(Vector3 dirXY)
    {
      
    }
}
