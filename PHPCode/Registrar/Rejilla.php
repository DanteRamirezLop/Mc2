<?php
     include_once 'Conexion.php';	 
	 
	$idItem =$_POST["idItem"];
	$idEquipo =$_POST["idEquipo"];
	$conexion =$_POST["conexion"];
	//---------------
	//$id = $_POST["id"];
	$nombre =$_POST["nombre"];
	$cfm =$_POST["cfm"];
	 
	$sql ="INSERT INTO rejilla (id,nombre,cfm) 
	VALUES ('".$idItem."','".$nombre."','".$cfm."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso Rejilla";
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