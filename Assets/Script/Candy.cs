using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class Candy: MonoBehaviour {
    public Vector3 mScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 mPos;  //物体目标地址

    public int mCol = 0;  //纵序号
    public int mRow = 0;  //横序号
    public float mSpeed = 45f;
    public _TYPE mType = _TYPE.NORMAL;

    public delegate void ExchangeEventHandler(object sender, ExchangeEventArgs e);
    private event ExchangeEventHandler ExchangeEvent;

    //是否是特殊糖果
    private bool mSpecial = false;  
    public bool isSpecial {
        get { return this.mSpecial; }
        set { this.mSpecial = value; }
    }

    // 索引，用于判断是哪种类型
    private int Index;
    public int mIndex {
        get { return this.Index; }
        set { this.Index = value; }
    }

    //是否到达指定位置
    private bool mStatic = false;
    public bool isStatic {
        get { return mStatic; }
    }

    public class ExchangeEventArgs: EventArgs {
        public ExchangeEventArgs() {
            this.mRow = 0;
            this.mCol = 0;
        }
        public ExchangeEventArgs(int col, int row) {
            this.mRow = row;
            this.mCol = col;
        }
        public int mRow;
        public int mCol;
    }

    void Start() {
        transform.localScale = this.mScale;
    }

    void Update() {
        float step = mSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mPos, step);
        mStatic = false;
        if(transform.position == mPos) {
            mStatic = true;
        }
    }

    void OnMouseEnter() {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.blue;
    }

    void OnMouseExit() {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    //private Vector3 screenPoint;
    //static public bool bDrag;  
    //void OnMouseDrag() {
    //    bDrag = true;
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    //    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + new Vector3(0, 0, 0.5f);
    //    transform.position = curPosition;
    //    print("curPosition" + curPosition);
    //}

    void OnMouseUpAsButton() {
        this.onSelected(new ExchangeEventArgs());
    }

    public void setDark(bool flag) {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        if(flag) {
            sr.color = Color.yellow;
        }
    }

    public void setChosen(bool ischosen) {
        if(ischosen) {
            this.transform.localScale = this.mScale * 1.2f;
        }
        else {
            this.transform.localScale = this.mScale * 1f;
        }
    }

    protected virtual void onSelected(ExchangeEventArgs e) {
        if(null != this.ExchangeEvent) {
            ExchangeEvent(this, e);
        }
    }

    public void AttachEventCallback(ExchangeEventHandler eeh) {
        this.ExchangeEvent += eeh;
    }

    public void DetachEventCallback(ExchangeEventHandler eeh) {
        this.ExchangeEvent -= eeh;
    }
}
