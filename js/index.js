function SendRequest(url, dataType, context, data, funcion){
	$.ajax({
		url: url,
		async: true,
		context: context || null,
		data: data,
		type: "POST",
		dataType: dataType || "json",
		xhr: function(){
			var myXhr = $.ajaxSettings.xhr();
			if (myXhr.upload) {
			}
			return myXhr;
		},
		beforeSend: function(){

		},
		complete: function(){

		},
		success: funcion || function(data){
			alert(data);
		},
		error: function (data){
			console.log("Error fn -> " + data);
		},
		processData: false,
		contentType: false
	});
}
$(document).ready(TraerPublicacion);
function TraerPublicacion(){
	var frmData = new FormData();
	SendRequest("lib/test.php","html",this,frmData,null);
}
