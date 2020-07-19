<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $idItem =$_POST["idItem"];
	 $conexion =$_POST["conexion"];
	 $giroX =$_POST["giroX"];
	 $giroY =$_POST["giroY"];
	 
	$sql ="INSERT INTO union (idItem,conexion,giroX,giroY) 
	VALUES ('".$idItem."','".$conexion."','".$giroX."','".$giroY."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>