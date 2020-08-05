<?php
     include_once 'Conexion.php';	 
	 
	 $idDucto = $_POST["idDucto"];
	 $ccx =$_POST["ccx"];
	 $ccy =$_POST["ccy"];
	 $ccz =$_POST["ccz"];
	 $paso =$_POST["paso"];
	 $dibujar =(int)$_POST["dibujar"];
	 
	$sql ="INSERT INTO ductopass (idDucto,ccx,ccy,ccz,paso,dibujar) 
	VALUES ('".$idDucto."','".$ccx."','".$ccy."','".$ccz."','".$paso."','".$dibujar."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>