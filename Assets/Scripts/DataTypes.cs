using UnityEngine;

namespace DataTypes
{
    public enum GamePanel
    {
        /// <summary> 스테이지 실패 </summary>
        GAME_OVER = 0,
        /// <summary> 스테이지 성공 </summary>
        NEXT_STAGE = 1,
        /// <summary> 모든 스테이지 종료 </summary>
        GAME_END = 2
    }

    public enum GameItem
    {
        /// <summary> 폭탄 </summary> 
        BOMB = 0,
        /// <summary> 자석 </summary> 
        MAGNET = 1,
        /// <summary> 밀치기 </summary> 
        KNOCKBACK = 2,
        /// <summary> </summary> 
        GHOTS = 3,
        /// <summary> </summary> 
        CLEANER = 4,
        /// <summary> </summary> 
        ZEROGRAVITY = 5
    }

    
}
