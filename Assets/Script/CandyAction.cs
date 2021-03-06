﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class CandyAction: MonoBehaviour {
    public int mCol = 0;  //纵序号
    public int mRow = 0;  //横序号
    public bool isReorder = true;
    public Vector3 mPos;
    public bool isDestroy = false;
    public float mSpeed = 45f;

    /// <summary>
    /// 索引，用于判断是哪种类型
    /// </summary>
    /// <value>The index of the m.</value>
    public int mIndex {
        get { return this.Index; }
        set { this.Index = value; }
    }

    private int Index;  //序号
    private bool isChosen = false;  //选中状态
    public bool isStatic = false;

    void Start() {

    }

    void Update() {
        float step = mSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mPos, step);
        isStatic = false;
        if(transform.position == mPos) {
            isStatic = true;
        }
    }

    void OnMouseUpAsButton() {
        this.isChosen = !this.isChosen;
        SendMessageUpwards("apply_exchange_pos", this);
    }
}
