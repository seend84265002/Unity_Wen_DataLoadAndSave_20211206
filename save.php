<?php
	// �s�u��� = �s�u(���A����}�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��)
$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");
	//�����ܼ� =Unit �z�LPOST �ǿ��� �A�W�� �� coin �����
	$coin = $_POST["coin"];
	$posX = $_POST["posX"];
	$posY = $_POST["posY"];
	//��s playerdata�s�� 1 ��������70
	//��s playerdata�]�w  coin =70 ��m playerdata.id=1
	//��s playerdata�]�w  coin =70 ��m playerdata.id=1
	$sqlCoin = "UPDATE `playerdata` SET `coin` = '" .$coin. "' WHERE `playerdata`.`id` = 1";
	$sqlX = "UPDATE `playerdata` SET `posX` = '" .$posX. "' WHERE `playerdata`.`id` = 1";
	$sqlY = "UPDATE `playerdata` SET `posY` = '" .$posY. "' WHERE `playerdata`.`id` = 1";
	//���� SQL (�s�u��� �A�d�߸��)
	mysqli_query($connrnt, $sqlCoin);
	mysqli_query($connrnt, $sqlX);
	mysqli_query($connrnt, $sqlY);

?>