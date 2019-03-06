using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CheckableObject : VRTK_InteractableObject
{
    [Tooltip("物体被拿到手中，变为原先大小的倍数")]
    public float suitableScale = 0.2f;
    public GameObject toolTip;
    private MachinePartBackLerpController backLerpController;

    /// <summary>
    /// 重写父类方法，抓取物体的时候
    /// 物体的大小变为适当大小
    /// </summary>
    /// <param name="usingObject">被使用的物体</param>
    public override void Grabbed(GameObject usingObject)
    {
        base.Grabbed(usingObject);
        // 抓取到手中时，大小变为合适大小
        this.transform.localScale = new Vector3(suitableScale, suitableScale, suitableScale);
        toolTip.transform.localScale = new Vector3(1/ suitableScale, 1 / suitableScale, 1 / suitableScale);
    }

    /// <summary>
    /// 重写父类方法，停止抓取物体的时候
    /// 物体可以开始返回原本Transform
    /// </summary>
    /// <param name="usingObject">被使用的物体</param>
    public override void Ungrabbed(GameObject usingObject)
    {
        //松手时，变为原本大小
        transform.localScale = new Vector3(1,1,1);
        toolTip.transform.localScale = new Vector3(1, 1, 1);
        backLerpController.IsCanBack();
        StopUsing(this.gameObject);
        base.Ungrabbed(usingObject);
    }

    /// <summary>
    /// 重写父类方法，开始使用物体
    /// 显示物体信息说明
    /// </summary>
    /// <param name="usingObject">被使用的物体</param>
    public override void StartUsing(GameObject usingObject)
    {
        base.StartUsing(usingObject);
        toolTip.SetActive(true);
    }

    /// <summary>
    /// 重写父类方法，停止使用物体
    /// 关闭物体信息说明
    /// </summary>
    /// <param name="usingObject">被使用的物体</param>
    public override void StopUsing(GameObject usingObject)
    {
        base.StopUsing(usingObject);
        toolTip.SetActive(false);
    }

    void Start()
    {
        backLerpController = GetComponent<MachinePartBackLerpController>();
    }
}
