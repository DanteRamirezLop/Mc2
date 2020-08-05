<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $nombre =$_POST["nombre"];
	 
	$sql ="INSERT INTO proyecto (nombre) VALUES ('".$nombre ."')";	
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso - Proyecto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>