<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 
	$sql ="DELETE FROM item WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminarcion exitoso Item";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>