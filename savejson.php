<?php
	// �s�u��� = �s�u(���A����}�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��)
	$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");
	//�����ܼ� =Unit �z�LPOST �ǿ��� �A�W�� �� json �����
	$json = $_POST["json"];

	//��s playerdata�]�w  json =$json ��m playerdata.id=1
	$sql = "UPDATE `playerjson` SET `json` = '".$json."' WHERE `playerjson`.`id` = 1";

	//���� SQL (�s�u��� �A�d�߸��)
	mysqli_query($connrnt, $sql);


?>