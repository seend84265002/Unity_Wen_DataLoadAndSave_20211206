<?php
// �s�u��� = �s�u(���A����}�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��)
$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");

//Unity �n�d�ߪ���� - search���
$json=$_POST["json"];
//����Ū���������
//$search="coin";

//SQL �d��
$sql = "SELECT `".$json."` FROM `playerjson` WHERE 1";
//�d�ߵ��G = SQL �d��(�s�u��� �A�d��)
$result = mysqli_query($connrnt , $sql);

//��ư}�C = �d�ߵ��G��C(�d�ߵ��G) - �N�d�ߵ��G�ର�}�C���
$data = mysqli_fetch_row($result);

//��X �d�ߵ��G ������W
echo $data[0];

?>