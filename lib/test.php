<?php
namespace
{
	include 'conexion.php';
	use ConexionNamespace\Conexion as Conexion;
	$cnx = new Conexion();
	$rs = $cnx->Seleccion("select * from Publicacion");
	$arrDatos = array();
	$j = 0;
	while (odbc_fetch_row($rs)) 
	{
		for($i=1;$i<=odbc_num_fields($rs);$i++)
		{
			$arrDatos[$j][] = odbc_result($rs, $i);
		}
		$j++;
	}
	print_r($arrDatos);
}
?>
