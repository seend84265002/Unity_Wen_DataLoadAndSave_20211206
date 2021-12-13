using UnityEngine;
namespace Wen
{
    /// <summary>
    /// ���a�����JSON���
    /// </summary>
    public class PlayerData 
    {
        public int coin;
        public float posX;
        public float posY;
        public Quaternion angle;
        public float time;
        //�غc�l:�L�Ǧ^�åB�W�ٻP���O�@�˪���k
        //�|�b�����O��������ɰ���@���A�B�z��l��
        /// <summary>
        /// �إߪ��a��ƨýᤩ��
        /// </summary>
        /// <param name="coin">����</param>
        /// <param name="posX">�y��X</param>
        /// <param name="posY">�y��Y</param>
        public PlayerData(int coin ,float posX,float posY)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;

        }
        public PlayerData(int coin, float posX, float posY,Quaternion angle,float time)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;
            this.angle = angle;
            this.time = time;
        }
    }

}
