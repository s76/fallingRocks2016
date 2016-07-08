using UnityEngine;
using System.Collections;

namespace s76ToolBox.Structures
{
    public class Vec2Int 
    {
        int x, y;

        public Vec2Int() : this(0, 0) { }
        public Vec2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vec2Int operator+ (Vec2Int t1, Vec2Int t2 )
        {
            return new Vec2Int(t1.x + t2.x, t1.y + t2.y);
        }
    }

}
