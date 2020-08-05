<?php
     include_once 'Conexion.php';	 
	 
	$id = $_POST["id"];

	$sql ="DELETE FROM equipoesp WHERE idEquipoV= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitoso-Equipoesp";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="DELETE FROM equipov WHERE id= '".$id."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Eliminacion exitoso-Equipov";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$conn->close();
?>