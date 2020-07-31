<?php
     include_once 'Conexion.php';	 
	 
	 $idDucto = $_POST["idDucto"];
	 $tipo =$_POST["tipo"];
	 $nombre =$_POST["nombre"];
	 $dimA =$_POST["dimA"];
	 $dimB =$_POST["dimB"];
	 $flujoCFM =$_POST["flujoCFM"];
	 $damAb100 =$_POST["damAb100"];
	 $damCer10 =$_POST["damCer10"];
	 $damCer50 =$_POST["damCer50"];
	 $tranRec =$_POST["tranRec"];
	 $conVen =$_POST["conVen"];
	 $lumAli =$_POST["lumAli"];
	 
	$sql ="UPDATE ductoex SET tipo='"
	.$tipo."','nombre=".$nombre."','dimA=".$dimA."','dimB=".$dimB."','flujoCFM=".$flujoCFM."','damAb100=".$damAb100."','damCer10=".$damCer10."','damCer50=".$damCer50."','tranRec=".$tranRec."','conVen=".$conVen."','lumAli=".$lumAli.
	 "'WHERE idDucto='".$idDucto"'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>