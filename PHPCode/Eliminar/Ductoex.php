<?php
     include_once 'Conexion.php';	 
	 
	 $idDucto = $_POST["idDucto"];

	 
	$sql ="DELETE FROM ductoex WHERE idDucto= '".$idDucto."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>