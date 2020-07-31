<?php
     include_once 'Conexion.php';	 
	 
	$id = $_POST["id"];
	$nombre =$_POST["nombre"];
	$cfm =$_POST["cfm"];
	 
	$sql =" UPDATE rejilla SET nombre='".$nombre."','cfm=".$cfm."' WHERE id ='".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>