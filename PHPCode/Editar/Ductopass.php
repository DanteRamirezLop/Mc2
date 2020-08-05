<?php
     include_once 'Conexion.php';	 
	 
	 $idDucto = $_POST["idDucto"];
	 $ccx =$_POST["ccx"];
	 $ccy =$_POST["ccy"];
	 $ccz =$_POST["ccz"];
	 $paso =$_POST["paso"];
	 $dibujar =(int)$_POST["dibujar"];
	 
	$sql ="UPDATE ductoPASS SET ccx='".$ccx."',ccy='".$ccy."',ccz='".$ccz."',paso='".$paso."',dibujar='".$dibujar."' WHERE idDucto='".$idDucto ."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>