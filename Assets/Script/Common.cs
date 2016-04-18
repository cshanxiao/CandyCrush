using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum _OPERATIONS {
    NONE = 0,  //无动作
    RESET = 1,  //重置位置
    NEW = 2,  //新生成糖果
    DESTROY = 3,  //销毁糖果
    EXCHANGE = 4,  //交换糖果
    MATCH = 5,  //匹配糖果
    GROUP = 6,  //分组
    DESPLAY = 7  //显示
}

public enum _STATUS {
    READY = 0,  //准备
    CHECKING = 1,  //正在检测
    DESTROYING = 2,  //正在销毁
    BUSY = 3  //未知繁忙
}

//糖果类型
public enum _TYPE {
    NORMAL = 0,  //普通糖果
    STREAKH = 1,  //斑纹横纹糖果
    STREAKV = 2,  //斑纹纵纹糖果
    PACKAGE = 3,  //包装糖果
    COLORFUL = 4  //彩色糖果
}

public struct SCandy {
    public int mCol;  //列序号
    public int mRow;  //行序号
    public _TYPE mType;  //糖果类型
    public int mIndex;  //糖果索引

    public SCandy(int pCol, int pRow, _TYPE pType, int pIndex) {
        this.mCol = pCol;
        this.mRow = pRow;
        this.mType = pType;
        this.mIndex = pIndex;
    }
}

public class Common {

}



