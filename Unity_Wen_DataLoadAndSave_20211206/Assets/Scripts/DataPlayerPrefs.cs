using UnityEngine;
namespace Wen
{
    /// <summary>
    /// ��Ʀs��
    /// PP �Ҧ� : �ϥ�Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataLoadAndSaveBase
    {
        [Header("PP �M���x�s��� KEY")]
        public string keyGold = "�����ƶq";
        public string keyX = "���aX�b";
        public string KeyY = "���aY�b";
        public override void SaveData()
        {
            
            base.SaveData();
            PlayerPrefs.SetInt(keyGold, goldManger.goldCount);
            PlayerPrefs.SetFloat(keyX, player.position.x);
            PlayerPrefs.SetFloat(KeyY, player.position.y);
        }
        public override void LoadData()
        {
            base.LoadData();
            #region Ū�����
            goldManger.goldCount = PlayerPrefs.GetInt(keyGold);
            Vector3 positionLoad = Vector3.zero;
            positionLoad.x = PlayerPrefs.GetFloat(keyX);
            positionLoad.y = PlayerPrefs.GetFloat(KeyY);
            #endregion


            #region ��s����
            goldManger.UpdataData();
            player.position = positionLoad;
            #endregion
        }
    }
}


