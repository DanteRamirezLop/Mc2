<?php
     include_once 'Conexion.php';	 
	 
	 $idEquipoV = $_POST["idEquipoV"];

	$sql ="DELETE FROM equipoesp WHERE idEquipoV= '".$idEquipoV."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>