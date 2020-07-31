<?php
     include_once 'Conexion.php';

	 $id = $_POST["id"];
	 	
     $sql = "DELETE FROM ambiente WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "MENSAJE API: Eliminacion exitoso en la BD";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>