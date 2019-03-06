using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePartBackLerpController : MonoBehaviour {

    //返回位置
    private Vector3 backPosition;
    private Quaternion backRotation;

    //是否返回
    private bool isBack = false;

    //是否完成返回
    bool isHaveReturn = false;

    //返回移动速度
    public float smoothSpeed = 5.0f;
    //返回旋转速度
    public float rotateSpeed = 0.1f;

    void Start()
    {
        backPosition = transform.position;
        backRotation = transform.rotation;
    }

    void Update()
    {
        if (isBack)
        {
            //矫正position
            transform.position = Vector3.Lerp(transform.position,
                backPosition, Time.deltaTime * smoothSpeed);

            //矫正rotation，需为四元数
            transform.rotation = Quaternion.Lerp(transform.rotation,
                backRotation, rotateSpeed);

            //当角度、距离差值均为0的时候，停止返回动作
            if (Vector3.Distance(transform.position, backPosition) <= 0.001)
            {
                isHaveReturn = true;
                isBack = false;
                //重新激活Adjust脚本
            }
        }
    }

    //如被调用，则执行返回动作
    public void IsCanBack()
    {
        //开始返回
        isBack = true;
    }

    public bool IsHaveReturn()
    {
        return isHaveReturn;
    }
}


