<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	$nombre =$_POST["nombre"];
	$cfm =$_POST["cfm"];
	 
	$sql ="INSERT INTO rejilla (nombre,cfm) 
	VALUES ('".$nombre."','".$cfm."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>