<?php
     include_once 'Conexion.php';	 
	 
	 $idEquip = $_POST["idEquip"];
	 //$idFiltro =$_POST["idFiltro"];
	 
	$sql ="DELETE FROM espfiltro WHERE idEquip= '".$idEquip."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>