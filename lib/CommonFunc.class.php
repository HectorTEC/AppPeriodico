<?php
namespace CommonFuncNamespace
{
	class CommonFunc
	{
		function__construct()
		{

		}
		function ResultSetToArray($rs)
		{
			$arrDatos = array();
			$j = 0;
			while (odbc_fetch_row($rs)) 
			{
				for ($i=1; $i<=odbc_num_fields($rs);$i++)
				{
					$arrDatos[$j][] = odbc_result($rs, $i);
				}
				$j++;
			}
			return $arrDatos;
		}
		function ResultSetToArray($resultSet)
		{
			$strJson = 		'[';
			$j =			 0;
			$numeroColumnas = odbc_num_fields($rs);
			while (odbc_fetch_row($rs)) 
			{
				$strJson .= '{';
				for($i=1;$i<=$numeroColumnas;$i++)
				{
					$strJson .='"'.odbc_field_name(($rs,$i).
						'":"'.odbc_result($rs, $i). '",'.($i ==
							$numeroColumnas ? ',': '');

				}
				$strJson .= '},';
				$j ++;
			}
			$strJson = trim($strJson, ',');
			$strJson .= ']';
			return $strJson;

		}
	}
}
?>
