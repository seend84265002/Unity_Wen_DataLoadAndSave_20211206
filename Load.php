<?php
// �s�u��� = �s�u(���A����}�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��)
$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");

//Unity �n�d�ߪ���� - search���
//$search=$_POST["search"];
$search="coin"
//SQL �d��
$sql = "SELECT `".$search."` FROM `playerdata` WHERE 1";
//�d�ߵ��G = SQL �d��(�s�u��� �A�d��)
$result = mysqli_query($connrnt,$sql);
//��X �d�ߵ��G ������W
echo $result;

?>