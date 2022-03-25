using UnityEngine;

namespace Level
{
    public class ILevel_System
    {
        protected int[] expIntervals;
        protected int[] atkIntervals;
        protected int[] hpIntervals;
        protected int[] mpIntervals;
        protected int chrIdx;
        protected int playerLv = 1;
        protected int playerExp;
        public int maxLv;
        public int maxExp;
        protected bool isMax;
        protected int gamePlayExp;
        protected int nextLVExp;
        protected int atkValue;
        protected int hpValue;
        protected int mpValue;
        protected int currentExpInterval;
        public ILevel_System(int exp) { playerExp = exp; }

        public virtual void Initial()
        {
            maxLv = expIntervals.Length;
            maxExp = expIntervals[expIntervals.Length - 1];
            playerLv = UpdateChrLevel(playerExp);
        }

        public virtual void AddExp(int value)
        {
            if (playerExp + value <= maxExp)
            {
                playerExp += value;
                if (playerExp <= 0)
                {
                    playerExp = 0;
                }
            }
            else
            {
                playerExp = maxExp;
            }
            
            if (playerExp >= nextLVExp)
            {
                if (playerLv < maxLv)
                {
                    LevelUp();
                }
            }
            playerLv = UpdateChrLevel(playerExp);
        }

        public int GetGamePlayExp()
        {
            return gamePlayExp;
        }

        public int GetExp()
        {
            return playerExp;
        }

        public int GetLv()
        {
            return playerLv;
        }

        public bool GetIsMax()
        {
            return isMax;
        }

        public int GetExpIntervalValue()
        {
            if (playerLv == 1)
            {
                return 0;
            }
            return expIntervals[currentExpInterval];
        }

        protected virtual int UpdateChrLevel(int expValue)
        {
            int value = 0;
            for (int i = 0; i < expIntervals.Length; ++i)
            {
                if (expValue >= expIntervals[i])
                {
                    value = i + 1;
                    if (i == 0)
                    {
                        currentExpInterval = 0;
                    }
                    else { currentExpInterval = i; }
                    atkValue = atkIntervals[i];
                    hpValue = hpIntervals[i];
                    mpValue = mpIntervals[i];
                    isMax = (value == maxLv);
                    if (i == expIntervals.Length - 1)
                    {
                        nextLVExp = expIntervals[i];
                    }
                    else
                    {
                        if (expValue < expIntervals[i + 1])
                        {
                            nextLVExp = expIntervals[i + 1];
                            break;
                        }
                    }
                }
            }
            return value;
        }

        public virtual int GetAtkBaseValue()
        {
            return atkValue;
        }

        public virtual int GetHPBaseValue()
        {
            return hpValue;
        }

        public virtual int GetMPBaseValue()
        {
            return mpValue;
        }

        public int GetNextLvExpValue()
        {
            if (playerLv == maxLv)
            {
                return expIntervals[playerLv - 1];
            }
            return expIntervals[playerLv];
        }

        public virtual void LevelUp()
        {
#if UNITY_EDITOR
            Debug.Log("Level Up!!");
#endif
        }
    }
}