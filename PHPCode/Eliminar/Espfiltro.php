<?php
     include_once 'Conexion.php';	 
	 
	 $idEquip = $_POST["idEquip"];
	 $idFiltro =$_POST["idFiltro"];
	 
	$sql ="DELETE FROM espfiltro WHERE idEquip= '".$idEquip."' AND idFiltro='".$idFiltro."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitoso - Espfiltro";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>