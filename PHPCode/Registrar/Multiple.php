<?php
     include_once 'Conexion.php';	 
	 
	 $idItem =$_POST["idItem"];
	 $idEquipo =$_POST["idEquipo"];
	 $conexion =$_POST["conexion"];
	 //-------------
	 //$id = $_POST["id"];
	 $giroX =$_POST["giroX"];
	 $giroY =$_POST["giroY"];
	 
	$sql ="INSERT INTO multiple (id,giroX,giroY) 
	VALUES ('".$idItem."','".$giroX."','".$giroY."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso Multiple";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="INSERT INTO item (idItem,idEquipo,conexion) 
	VALUES ('".$idItem."','".$idEquipo."','".$conexion."')";
	
	if($conn->query($sql_2)===TRUE){
		echo "Registro exitoso Item";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$conn->close();
?>