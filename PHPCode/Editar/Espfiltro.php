<?php
     include_once 'Conexion.php';	 
	 
	 $idEquip = $_POST["idEquip"];
	 $idFiltro =$_POST["idFiltro"];
	 
	$sql ="UPDATE espfiltro SET idFiltro='".$idFiltro."' WHERE idEquip='".$idEquip."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso Espfiltro";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>