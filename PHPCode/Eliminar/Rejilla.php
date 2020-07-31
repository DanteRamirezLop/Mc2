<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 
	 $sql ="DELETE FROM rejilla WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>