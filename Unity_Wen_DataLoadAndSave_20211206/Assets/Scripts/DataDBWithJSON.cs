using UnityEngine;

namespace Wen
{
    /// <summary>
    /// �z�L��Ʈw�s�����
    /// ��Ƴz�LJSON
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        public override void SaveData()
        {
            base.SaveData();

            //�s�W���a��ƨ��x�s�����P�y��
            PlayerData data = new PlayerData(goldManger.goldCount, player.position.x, player.position.y);
            //JSON �r��(JSON�x�s����쳣�O�r��) = JSON ���.�� JSON(���a���)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON ���:<color=yellow>" + dataJSON + "</color>");
        }
        public override void LoadData()
        {
            base.LoadData();
        }
    }
}

